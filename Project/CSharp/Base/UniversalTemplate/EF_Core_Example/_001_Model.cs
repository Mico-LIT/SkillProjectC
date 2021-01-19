using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.EF_Core_Example
{
    public class _001_Model
    {
        public interface IEntity
        {
            int Id { get; set; }
            bool IsValid();
        }

        public class Employee : IEntity
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public bool IsValid()
            {
                return true;
            }
        }


        public interface IRepository<T> : IDisposable
        {
            void Add(T item);
            void Deleted(T item);
            T FindById(int id);
            IQueryable<T> FindAll();
            int Commit();
        }
    }
}
