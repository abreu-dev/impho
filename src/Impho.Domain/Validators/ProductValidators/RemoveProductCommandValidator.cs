using FluentValidation;
using Impho.Domain.Commands.ProductCommands;

namespace Impho.Domain.Validators.ProductValidators
{
    public class RemoveProductCommandValidator : AbstractValidator<RemoveProductCommand>
    {
        public RemoveProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty();
        }
    }
}
