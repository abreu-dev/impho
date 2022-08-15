using Impho.Core.Data.Entities;
using Impho.Domain.Enums;

namespace Impho.Infra.Data.Entities
{
    public class ProductData : EntityData
    {
        public static string TableName => "Product";

        public string Name { get; set; }
        public string Description { get; set; }
        public int QuantityAvailable { get; set; }
        public UnitOfMeasurement UnitOfMeasurement { get; set; }
        public double CurrencyValue { get; set; }
        public string CurrencyCode { get; set; }
    }
}
