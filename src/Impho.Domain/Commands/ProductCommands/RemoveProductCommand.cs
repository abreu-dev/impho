using Impho.Core.Messaging.Commands;
using Impho.Domain.Validators.ProductValidators;

namespace Impho.Domain.Commands.ProductCommands
{
    public class RemoveProductCommand : Command
    {
        public Guid Id { get; private set; }

        public RemoveProductCommand(Guid id)
        {
            Id = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProductCommandValidator().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
