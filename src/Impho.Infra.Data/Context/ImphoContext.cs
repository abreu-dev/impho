using Impho.Core.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Reflection;

namespace Impho.Infra.Data.Context
{
    public class ImphoContext : DbContext, IImphoContext
    {
        public ImphoContext(DbContextOptions<ImphoContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public bool IsAvailable()
        {
            return Database.CanConnect();
        }

        public DbSet<TEntity> GetDbSet<TEntity>() where TEntity : EntityData
        {
            return Set<TEntity>();
        }

        public EntityEntry<TEntity> GetDbEntry<TEntity>(TEntity data) where TEntity : EntityData
        {
            return Entry(data);
        }

        public IQueryable<TEntity> Query<TEntity>() where TEntity : EntityData
        {
            return Set<TEntity>().AsQueryable();
        }

        public void AddData<TEntity>(TEntity data) where TEntity : EntityData
        {
            Add(data);
        }

        public void UpdateData<TEntity>(TEntity data) where TEntity : EntityData
        {
            var existingData = GetDbSet<TEntity>().SingleOrDefault(x => x.Id == data.Id);

            if (existingData != null)
            {
                GetDbEntry(existingData).CurrentValues.SetValues(data);
            }
        }

        public void DeleteData<TEntity>(TEntity data) where TEntity : EntityData
        {
            Remove(data);
        }

        public void Complete()
        {
            SaveChanges();
        }
    }
}
