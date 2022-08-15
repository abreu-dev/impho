using Impho.Core.Messaging.Commands;

namespace Impho.Core.Messaging.Dispatchers.Interfaces
{
    public interface ICommandDispatcher
    {
        Task Dispatch<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand;
    }
}
