using Impho.Core.Data;
using Impho.Core.Data.Adapters;
using Impho.Core.Data.Entities;
using Impho.Core.Domain.Entities;
using Impho.Core.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Impho.Core.Domain.Repositories
{
    public abstract class Repository<TEntityDomain, TEntityData> : IRepository<TEntityDomain>
        where TEntityDomain : EntityDomain
        where TEntityData : EntityData
    {
        protected readonly IBaseContext _context;
        protected readonly IDataAdapter<TEntityDomain, TEntityData> _adapter;

        private readonly DbSet<TEntityData> _dbSet;

        protected Repository(IBaseContext context,
                             IDataAdapter<TEntityDomain, TEntityData> adapter)
        {
            _context = context;
            _adapter = adapter;

            _dbSet = _context.GetDbSet<TEntityData>();
        }

        public IUnitOfWork UnitOfWork => _context;

        public IEnumerable<TEntityDomain> GetAll()
        {
            return _adapter.Transform(_dbSet.AsNoTracking());
        }

        public TEntityDomain? GetById(Guid id)
        {
            var data = _dbSet.AsNoTracking()
                .FirstOrDefault(x => x.Id == id);

            if (data == null) return null;

            return _adapter.Transform(data);
        }

        public virtual void Add(TEntityDomain domain)
        {
            var data = _adapter.Transform(domain);
            if (data != null) _context.AddData(data);
        }

        public virtual void Update(TEntityDomain domain)
        {
            var data = _adapter.Transform(domain);
            if (data != null) _context.UpdateData(data);
        }

        public virtual void Delete(Guid id)
        {
            var data = _dbSet.FirstOrDefault(x => x.Id == id);

            if (data != null) _context.DeleteData(data);
        }

        public bool Exists(Guid id)
        {
            return _dbSet.AsNoTracking().Any(x => x.Id == id);
        }
    }
}
