using Impho.Core.Messaging.Queries;

namespace Impho.Core.Messaging.Dispatchers.Interfaces
{
    public interface IQueryDispatcher
    {
        Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellationToken) where TQuery : IQuery<TQueryResult>;
    }
}
