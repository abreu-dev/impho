using Impho.Core.Messaging.Commands;
using Impho.Domain.Validators.ProductValidators;

namespace Impho.Domain.Commands.ProductCommands
{
    public class AddProductCommand : Command
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int QuantityAvailable { get; private set; }
        public string UnitOfMeasurement { get; private set; }
        public double CurrencyValue { get; private set; }
        public string CurrencyCode { get; private set; }

        public AddProductCommand(string name, string description, int quantityAvailable, string unitOfMeasurement, double currencyValue, string currencyCode)
        {
            Name = name;
            Description = description;
            QuantityAvailable = quantityAvailable;
            UnitOfMeasurement = unitOfMeasurement;
            CurrencyValue = currencyValue;
            CurrencyCode = currencyCode;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddProductCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
