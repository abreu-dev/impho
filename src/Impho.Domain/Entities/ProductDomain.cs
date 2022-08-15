using Impho.Core.Domain.Entities;
using Impho.Domain.Enums;

namespace Impho.Domain.Entities
{
    public class ProductDomain : EntityDomain
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int QuantityAvailable { get; private set; }
        public UnitOfMeasurement UnitOfMeasurement { get; private set; }
        public CurrencyDomain Currency { get; private set; }

        public ProductDomain(string name, string description, int quantityAvailable, UnitOfMeasurement unitOfMeasurement, CurrencyDomain currency)
        {
            Name = name;
            Description = description;
            QuantityAvailable = quantityAvailable;
            UnitOfMeasurement = unitOfMeasurement;
            Currency = currency;
        }

        public ProductDomain(Guid id, string name, string description, int quantityAvailable, UnitOfMeasurement unitOfMeasurement, CurrencyDomain currency)
            : base(id)
        {
            Name = name;
            Description = description;
            QuantityAvailable = quantityAvailable;
            UnitOfMeasurement = unitOfMeasurement;
            Currency = currency;
        }
    }
}
