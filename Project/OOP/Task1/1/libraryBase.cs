using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Task1._1
{
    public abstract class libraryBase
    {
        protected abstract Dictionary<int,Book> Book { get; }
        public abstract void Add(Book bk);
        public abstract void Delete();
        public abstract IEnumerable<Book> Find(int id);
    }
}
