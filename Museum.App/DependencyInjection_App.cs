using Microsoft.Extensions.DependencyInjection;
using Museum_App.Interfaces;
using Museum_App.Services;

namespace Museum_App
{

    public static class DependencyInjection_App
    {
        public static IServiceCollection AddAppDI(this IServiceCollection services)
        {
            services.AddScoped<ITicketPricingService, TicketPricingService>();
            services.AddScoped<ITicketSaleService, TicketSaleService>();

            return services;
        }
    }
}

