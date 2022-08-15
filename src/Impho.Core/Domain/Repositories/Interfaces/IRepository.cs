using Impho.Core.Data;
using Impho.Core.Domain.Entities;

namespace Impho.Core.Domain.Repositories.Interfaces
{
    public interface IRepository<TEntityDomain> where TEntityDomain : EntityDomain
    {
        IUnitOfWork UnitOfWork { get; }

        IEnumerable<TEntityDomain> GetAll();
        TEntityDomain? GetById(Guid id);

        void Add(TEntityDomain domain);
        void Update(TEntityDomain domain);
        void Delete(Guid id);

        bool Exists(Guid id);
    }
}
