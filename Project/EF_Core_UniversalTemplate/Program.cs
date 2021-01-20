using Microsoft.EntityFrameworkCore;
using System;
using CSharp.Base.UniversalTemplate.EF_Core_Example;
using System.Linq;

namespace EF_Core_UniversalTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var sqlRepository = new SqlRepository<_001_Model.Employee>(new CompanyDb()))
            {
                sqlRepository.Add(new _001_Model.Employee() { Name = "1234" });
                sqlRepository.Commit();
                var employees = sqlRepository.FindAll.ToListAsync().Result;
            }
            
        }

        class CompanyDb : DbContext
        {
            public DbSet<_001_Model.Employee> Employees { get; set; }

            public CompanyDb()
            {
                Database.EnsureCreated();                
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseInMemoryDatabase("Test");
                //base.OnConfiguring(optionsBuilder);
            }

        }

        public class SqlRepository<T> : _001_Model.IRepository<T> where T : class ,_001_Model.IEntity
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
                if (item.IsValid())
                {
                    dbSet.Add(item);
                }
                else
                    throw new InvalidOperationException();

            }

            public int Commit()
            {
                throw new NotImplementedException();
            }

            public void Deleted(T item)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public IQueryable<T> FindAll()
            {
                throw new NotImplementedException();
            }

            public T FindById(int id)
            {
                throw new NotImplementedException();
            }
        }

    }
}
