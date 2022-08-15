using Impho.Core.Data.Adapters;
using Impho.Domain.Entities;
using Impho.Infra.Data.Adapters.Interfaces;
using Impho.Infra.Data.Entities;

namespace Impho.Infra.Data.Adapters
{
    public class ProductDataAdapter : DataAdapter<ProductDomain, ProductData>, IProductDataAdapter
    {
        public override ProductDomain? Transform(ProductData? data)
        {
            if (data == null) return null;

            var currency = new CurrencyDomain(data.CurrencyValue, data.CurrencyCode);
            return new ProductDomain(data.Id, data.Name, data.Description, data.QuantityAvailable, data.UnitOfMeasurement, currency);
        }

        public override ProductData? Transform(ProductDomain? domain)
        {
            if (domain == null) return null;

            return new ProductData()
            {
                Id = domain.Id,
                Name = domain.Name,
                Description = domain.Description,
                QuantityAvailable = domain.QuantityAvailable,
                UnitOfMeasurement = domain.UnitOfMeasurement,
                CurrencyValue = domain.Currency.Value,
                CurrencyCode = domain.Currency.Code
            };
        }
    }
}
