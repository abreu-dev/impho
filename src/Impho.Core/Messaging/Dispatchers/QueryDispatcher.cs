using Impho.Core.Messaging.Dispatchers.Interfaces;
using Impho.Core.Messaging.Handlers.Interfaces;
using Impho.Core.Messaging.Queries;
using Microsoft.Extensions.DependencyInjection;

namespace Impho.Core.Messaging.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery<TQueryResult>
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TQueryResult>>();
            return handler.Handle(query, cancellationToken);
        }
    }
}
