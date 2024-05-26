using EventRegistration.Application.UseCase.EventRegistration;
using EventRegistration.Application.UseCase.Events;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EventRegistration.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<GetAvailableEventsUseCase>();
            services.AddScoped<CreateEventUseCase>();
            services.AddScoped<UpdateEventUseCase>();
            services.AddScoped<DeleteEventsUseCase>();
            services.AddScoped<GetAllEventsUseCase>();
            services.AddScoped<CreateEventRegistrationUseCase>();

            return services;
        }
    }
}
