using Impho.Core.Data.Adapters;
using Impho.Domain.Entities;
using Impho.Infra.Data.Entities;

namespace Impho.Infra.Data.Adapters.Interfaces
{
    public interface IProductDataAdapter : IDataAdapter<ProductDomain, ProductData>
    {
    }
}
