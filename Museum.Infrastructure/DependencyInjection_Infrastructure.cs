using Microsoft.Extensions.DependencyInjection;
using Museum_App.Interfaces;
using Museum_Infrastructure.Services;

namespace Museum_Infrastructure
{
    public static class DependencyInjection_Infrastructure
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            services.AddScoped<IPaymentService, PosPaymentService>();
            services.AddScoped<IPrinterService, PrinterService>();

            return services;
        }
    }
}
