using FluentValidation;
using Impho.Domain.Commands.ProductCommands;

namespace Impho.Domain.Validators.ProductValidators
{
    public class AddProductCommandValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty();

            RuleFor(x => x.Description)
                .NotEmpty();

            RuleFor(x => x.QuantityAvailable)
                .NotEmpty();

            RuleFor(x => x.UnitOfMeasurement)
                .NotEmpty();

            RuleFor(x => x.CurrencyValue)
                .NotEmpty();

            RuleFor(x => x.CurrencyCode)
                .NotEmpty();
        }
    }
}
