using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Task1._1
{
    public class library : libraryBase
    {
        protected override Dictionary<int, Book> Book { get; }
        public library() { Book = new Dictionary<int, Book>(); }

        public override void Add(Book bk)
        {
            try
            {
                if (bk.Type == BookType.журнал)
                {
                    bk.BookAuthor = null;
                }
                Book.Add(bk.ID, bk);
            }
            catch (Exception)
            {
                Console.WriteLine("Кника сущевствует");
            }
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Find(string Name)
        {
            foreach (var item in Book.Where(x => x.Value.Name == Name))
            {
                yield return item.Value;
            } 
        }
        public override IEnumerable<Book> Find(int id)
        {
            foreach (var item in Book.Where(x => x.Key == id))
            {
                yield return item.Value;
            }
        }

    }
}
