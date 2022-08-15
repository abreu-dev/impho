using Impho.Core.Messaging.Commands;

namespace Impho.Core.Messaging.Handlers.Interfaces
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command, CancellationToken cancellationToken);
    }
}
