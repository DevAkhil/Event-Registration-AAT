using EventRegisterstration.Service.Interface;
using EventRegisterstration.Service.Persistance;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

namespace EventRegistration.UI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Configuration.AddJsonFile("appsettings.json");

            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddMudServices();


            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.Configuration["ApiSettings:BaseUrl"]!) });
            builder.Services.AddScoped<IEventService, EventService>();
            builder.Services.AddScoped<IEventRegistrationService, EventRegistrationService>();

            await builder.Build().RunAsync();
        }
    }
}
