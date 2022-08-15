using Impho.Core.Messaging.Queries;

namespace Impho.Core.Messaging.Handlers.Interfaces
{
    public interface IQueryHandler<in TQuery, TQueryResult> where TQuery : IQuery<TQueryResult>
    {
        Task<TQueryResult> Handle(TQuery query, CancellationToken cancellationToken);
    }
}
