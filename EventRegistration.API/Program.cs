
using EventRegistration.Application;
using EventRegistration.Domain.Repositories;
using EventRegistration.Infrastructure.Context;
using EventRegistration.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace EventRegistration.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<EventRegistrationContext>(options =>
                options.UseInMemoryDatabase(builder.Configuration.GetConnectionString("Default")!));
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAnyLocalhost",
                    builder =>
                    {
                        builder
                            .AllowAnyOrigin() // Allow requests from any origin
                            .AllowAnyMethod() // Allow any HTTP method
                            .AllowAnyHeader(); // Allow any header
                    });
            });


            builder.Services.AddApplicationServices();
            builder.Services.AddScoped<IEventRepository, EventRepository>();
            builder.Services.AddScoped<IEventReigstrationRepository, EventRegistrationRepository>();


            var app = builder.Build();
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var dbContext = services.GetRequiredService<EventRegistrationContext>();
                dbContext.Database.EnsureCreated();
            }
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("AllowAnyLocalhost");
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
