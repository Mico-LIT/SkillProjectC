using CSharp.Base.UniversalTemplate.EF_Core_Example;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EF_Core_UniversalTemplate.DataBase
{
    // Пример:
    //public class SqlRepository<T, T2, T3>    where T : class, _001_Model.IEntity, new()
    //                                         where T2 : class, IDisposable, IFormattable, new()
    //                                         where T3 : struct, IQueryable<T3>, IEquatable<T3>
    //{ }

    public class SqlRepository<T> : _001_Model.IRepository<T> where T : class, _001_Model.IEntity, new()
    {
        DbContext dbContext;
        DbSet<T> dbSet;

        public SqlRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
            dbSet = dbContext.Set<T>();
        }

        public void Add(T item)
        {
            if (item.IsValid)
            {
                dbSet.Add(item);
            }
            else
                throw new InvalidOperationException();

        }

        public int Commit()
        {
            return dbContext.SaveChanges();
        }

        public void Deleted(T item)
        {
            dbSet.Remove(item);
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }

        public IQueryable<T> FindAll()
        {
            return dbSet;
        }

        public T FindById(int id)
        {
            return dbSet.Find(id);
        }
    }
}
