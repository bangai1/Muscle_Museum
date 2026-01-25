using Museum_App;
using Museum_Domain;
using Museum_Infrastructure;

namespace Muscle_Museum    
{
    public static class DependencyInjection_Main
    {
        public static IServiceCollection AddWebDI(this IServiceCollection services)
        {
            services.AddAppDI();
            services.AddInfrastructureDI();
            services.AddDomainDI();

            return services;
        }
    }

}
