using FluentValidation;
using Impho.Core.Extensions;
using Impho.Domain.Commands.ProductCommands;
using Impho.Domain.Enums;

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
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.UnitOfMeasurement)
                .NotEmpty()
                .Must(x => BeValidUnitOfMeasurement(x));

            RuleFor(x => x.CurrencyValue)
                .GreaterThanOrEqualTo(0);

            RuleFor(x => x.CurrencyCode)
                .NotEmpty();
        }

        private bool BeValidUnitOfMeasurement(string unitOfMeasurement)
        {
            return EnumExtensions.IsAnEnumDisplayName<UnitOfMeasurement>(unitOfMeasurement);
        }
    }
}
