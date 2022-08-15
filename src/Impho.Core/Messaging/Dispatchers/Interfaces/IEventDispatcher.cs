using Impho.Core.Messaging.Events;

namespace Impho.Core.Messaging.Dispatchers.Interfaces
{
    public interface IEventDispatcher
    {
        Task Dispatch<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IEvent;
    }
}
