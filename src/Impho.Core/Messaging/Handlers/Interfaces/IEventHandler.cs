using Impho.Core.Messaging.Events;

namespace Impho.Core.Messaging.Handlers.Interfaces
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task Handle(TEvent @event, CancellationToken cancellationToken);
    }
}
