using Impho.Core.Data;
using Impho.Domain.Repositories;
using Impho.Infra.Data.Adapters;
using Impho.Infra.Data.Adapters.Interfaces;
using Impho.Infra.Data.Context;
using Impho.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Impho.Infra.Data
{
    public static class ImphoDataBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            Adapters(services);
            Context(services, configuration);
            Repositories(services);
        }

        public static void Adapters(IServiceCollection services)
        {
            services.AddScoped<IProductDataAdapter, ProductDataAdapter>();
        }

        public static void Context(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ImphoContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IImphoContext, ImphoContext>();
            services.AddScoped<IBaseContext, ImphoContext>();
            services.AddScoped<ImphoContext>();
        }

        public static void Repositories(IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }
}
