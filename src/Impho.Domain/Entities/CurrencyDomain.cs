namespace Impho.Domain.Entities
{
    public class CurrencyDomain
    {
        public double Value { get; private set; }
        public string Code { get; private set; }

        public CurrencyDomain(double value, string code)
        {
            Value = value;
            Code = code;
        }
    }
}
