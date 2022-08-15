using Impho.Core.Domain.Repositories;
using Impho.Domain.Entities;
using Impho.Domain.Repositories;
using Impho.Infra.Data.Adapters.Interfaces;
using Impho.Infra.Data.Context;
using Impho.Infra.Data.Entities;

namespace Impho.Infra.Data.Repositories
{
    public class ProductRepository : Repository<ProductDomain, ProductData>, IProductRepository
    {
        public ProductRepository(IImphoContext context, IProductDataAdapter adapter) : base(context, adapter)
        {
        }
    }
}
