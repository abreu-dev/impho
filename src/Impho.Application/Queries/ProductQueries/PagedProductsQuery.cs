using Impho.Application.Contracts;
using Impho.Application.Parameters.Interfaces;
using Impho.Core.Data.Pagination.Interfaces;
using Impho.Core.Messaging.Queries;

namespace Impho.Application.Queries.ProductQueries
{
    public class PagedProductsQuery : IQuery<IPagedList<ProductDto>>
    {
        public IProductParameters Parameters { get; private set; }

        public PagedProductsQuery(IProductParameters parameters)
        {
            Parameters = parameters;
        }
    }
}
