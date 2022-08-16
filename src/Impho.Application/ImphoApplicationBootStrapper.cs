using Impho.Application.Contracts;
using Impho.Application.Queries.Handlers;
using Impho.Application.Queries.ProductQueries;
using Impho.Core.Data.Pagination.Interfaces;
using Impho.Core.Messaging.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Impho.Application
{
    public static class ImphoApplicationBootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            Queries(services);
        }

        public static void Queries(IServiceCollection services)
        {
            services.AddScoped<IQueryHandler<PagedProductsQuery, IPagedList<ProductDto>>, ProductQueryHandler>();
            services.AddScoped<IQueryHandler<ExportProductsQuery, IEnumerable<ProductForExportDto>>, ProductQueryHandler>();
        }
    }
}
