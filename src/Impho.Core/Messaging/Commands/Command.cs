using FluentValidation.Results;

namespace Impho.Core.Messaging.Commands
{
    public abstract class Command : ICommand
    {
        public ValidationResult ValidationResult { get; protected set; }

        protected Command()
        {
            ValidationResult = new ValidationResult();
        }

        public abstract bool IsValid();
    }
}
