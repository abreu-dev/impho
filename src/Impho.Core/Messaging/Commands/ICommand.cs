using FluentValidation.Results;

namespace Impho.Core.Messaging.Commands
{
    public interface ICommand
    {
        ValidationResult ValidationResult { get; }

        bool IsValid();
    }
}
