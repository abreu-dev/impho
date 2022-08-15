using Impho.Core.Domain.Entities.Interfaces;

namespace Impho.Core.Domain.Entities
{
    public abstract class EntityDomain : IEntityDomain
    {
        public Guid Id { get; private set; }

        protected EntityDomain()
        {
            Id = Guid.NewGuid();
        }

        protected EntityDomain(Guid id)
        {
            Id = id;
        }
    }
}
