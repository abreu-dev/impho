using Impho.Core.Messaging.Dispatchers.Interfaces;
using Impho.Core.Messaging.Events;
using Impho.Core.Messaging.Handlers.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Impho.Core.Messaging.Dispatchers
{
    public class EventDispatcher : IEventDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public EventDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task Dispatch<TEvent>(TEvent @event, CancellationToken cancellationToken) where TEvent : IEvent
        {
            var handler = _serviceProvider.GetRequiredService<IEventHandler<TEvent>>();
            return handler.Handle(@event, cancellationToken);
        }
    }
}
