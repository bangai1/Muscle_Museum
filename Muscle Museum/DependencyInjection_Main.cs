using Microsoft.EntityFrameworkCore;
using Museum_App;
using Museum_Domain;
using Museum_Domain.Models;
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

            // DbContext
            services.AddDbContext<MuseumDbContext>(options =>
                options.UseSqlServer(
                    new ConfigurationBuilder()
                        .AddJsonFile("appsettings.json")
                        .Build()
                        .GetConnectionString("Default_Connection"),
                    b => b.MigrationsAssembly("Museum_Domain")
                ));


            return services;
        }
    }

}
