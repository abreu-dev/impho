using Impho.Core.Data.Entities;
using Impho.Core.Domain.Entities;

namespace Impho.Core.Data.Adapters
{
    public interface IDataAdapter<TEntityDomain, TEntityData>
        where TEntityDomain : EntityDomain
        where TEntityData : EntityData
    {
        TEntityDomain? Transform(TEntityData? data);
        IEnumerable<TEntityDomain> Transform(IEnumerable<TEntityData> datas);

        TEntityData? Transform(TEntityDomain? domain);
        IEnumerable<TEntityData> Transform(IEnumerable<TEntityDomain> domains);
    }
}
