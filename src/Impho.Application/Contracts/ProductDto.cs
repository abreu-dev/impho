namespace Impho.Application.Contracts
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int QuantityAvailable { get; set; }
        public string UnitOfMeasurement { get; set; }
        public double CurrencyValue { get; set; }
        public string CurrencyCode { get; set; }
    }
}
