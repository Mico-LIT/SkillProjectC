using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.EF_Core_Example
{
    public class _001_Model
    {
        public class Person
        {
            public string Name { get; set; }
        }

        public class Employee : Person, IEntity
        {
            public int Id { get; set; }
            public bool IsValid => true;

            public virtual void DoWork()
            {
                Console.WriteLine("doing real work");
            }
        }

        public class Manager : Employee
        {
            public override void DoWork()
            {
                Console.WriteLine("create meeting");
            }
        }

        public interface IEntity
        {
            int Id { get; set; }
            bool IsValid { get; }
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
