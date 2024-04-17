using Microsoft.EntityFrameworkCore;
using Senac.eShop.Infra.Data.Context;
using Senac.eShop.Infra.Identity.Data;

namespace Senac.eShop.API.Configuration
{
    public static class ConfigurationServicesExtensions
    {
        public static IServiceCollection DbContextConfigureServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<EShopDbContext>(options => options.UseSqlServer(connectionString));
            services.AddDbContext<IdentityDataContext>(options => options.UseSqlServer(connectionString));

            services.AddDistributedMemoryCache();

            return services;
        }
    }
}
