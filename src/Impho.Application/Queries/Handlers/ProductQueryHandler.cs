using Impho.Application.Contracts;
using Impho.Application.Queries.ProductQueries;
using Impho.Core.Data.Pagination;
using Impho.Core.Data.Pagination.Interfaces;
using Impho.Core.Extensions;
using Impho.Core.Messaging.Handlers.Interfaces;
using Impho.Infra.Data.Context;
using Impho.Infra.Data.Entities;

namespace Impho.Application.Queries.Handlers
{
    public class ProductQueryHandler :
        IQueryHandler<PagedProductsQuery, IPagedList<ProductDto>>
    {
        private readonly IImphoContext _context;

        public ProductQueryHandler(IImphoContext context)
        {
            _context = context;
        }

        public async Task<IPagedList<ProductDto>> Handle(PagedProductsQuery query, CancellationToken cancellationToken)
        {
            var source = _context.Query<ProductData>();

            source = source.OrderBy(p => p.Name);

            var totalItems = source.Count();

            var dtos = (from product in source
                        select new ProductDto()
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Description = product.Description,
                            QuantityAvailable = product.QuantityAvailable,
                            UnitOfMeasurement = product.UnitOfMeasurement.GetEnumDisplayName(),
                            CurrencyValue = product.CurrencyValue,
                            CurrencyCode = product.CurrencyCode,
                        })
                        .Skip(query.Parameters.Page * query.Parameters.Size)
                        .Take(query.Parameters.Size)
                        .ToList();

            return new PagedList<ProductDto>(dtos, totalItems, query.Parameters.Page, query.Parameters.Size);
        }
    }
}
