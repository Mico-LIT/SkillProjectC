using EF_CodeFirst.Examples._008_GenericRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Examples._008_GenericRepository
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        DbContext dbContext;
        DbSet<TEntity> dbSet;

        public EFGenericRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            dbSet.Add(entity);
            dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).ToList();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.AsNoTracking().ToList();
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
            dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        #region Expression

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            return Include(includeProperties).ToList();
        }

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity,bool> predicate, params Expression<Func<TEntity,object>>[] includeProperties)
        {
            var query = Include(includeProperties);

            return query.Where(predicate).ToList();
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProps)
        {
            IQueryable<TEntity> query = dbSet.AsNoTracking();

            return includeProps
                .Aggregate(query, (current, includeProp) => current.Include(includeProp));
        }

        #endregion

        ~EFGenericRepository()
        {
            if (dbContext!=null)
                dbContext.Dispose();
        }
    }
}
