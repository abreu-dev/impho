using CsvHelper.Configuration;
using Impho.Import.Entities;

namespace Impho.Import.Mappings
{
    public class ProductForImportDtoMap : ClassMap<ProductForImportDto>
    {
        public ProductForImportDtoMap()
        {
            Map(x => x.Name).Index(0);
            Map(x => x.Description).Index(1);
            Map(x => x.QuantityAvailable).Index(2);
            Map(x => x.UnitOfMeasurement).Index(3);
            Map(x => x.CurrencyValue).Index(4);
            Map(x => x.CurrencyCode).Index(5);
        }
    }
}
