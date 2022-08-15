using Impho.Core.Data.Entities.Interfaces;

namespace Impho.Core.Data.Entities
{
    public abstract class EntityData : IEntityData
    {
        public Guid Id { get; set; }
    }
}
