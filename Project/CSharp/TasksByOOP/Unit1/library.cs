using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.TasksByOOP.Unit1
{
    internal class library : libraryBase
    {
        public library() { }

        public override void AddBook(Book bk)
        {
            Book book = null;
            try
            {
                if (bk.Type == BookType.журнал)
                {
                    bk.BookAuthor = null;
                }
                book = Book.Find(x => x.ID == bk.ID);

                Book.Add(bk);
            }
            catch (Exception)
            {
                Console.WriteLine($"Кника c таким ID существует! ID={book.ID}/r {book.Name + " " + book.Type}");
            }
            finally
            {
                Console.WriteLine("Укажите новую книжку");
            }
        }

        public override bool DeleteBook(int id)
        {
            foreach (var item in Book.Where(x => x.ID == id))
            {
                Book.Remove(item);
                return true;
            }

            return false;
        }

        public IEnumerable<Book> FindBookName(string Name)
        {
            foreach (var item in Book.Where(x => x.Name == Name))
            {
                yield return item;
            }
        }
        public override Book FindBookID(int id)
        {
            return Book.SingleOrDefault(x => x.ID == id);
        }

        public override bool AddUser(User user)
        {
            if (User.FindIndex(x => x.ID == user.ID) < 0)
            {
                User.Add(user);
                return true;
            }
            return true;
        }

        public override bool DeleteUser(int userID)
        {
            if (User.Find(x => x.ID == userID) != null)
            {
                User.RemoveAll(x => x.ID == userID);
                return true;
            }
            return true;
        }

        public override bool AttachmentsUser(int userid, int bookid)
        {
            if (UserBook.Find(x => x.Book.ID == bookid) == null)
            {
                User user = User.Find(x=>x.ID == userid);
                Book book = Book.Find(x => x.ID == bookid);
                UserBook.Add(new UserBook()
                {
                    User = user,
                    Book = book,
                    DateTimeStart = DateTime.Now.Date,
                    ID = UserBook.Count
                });
                return true;
            }

            return false;
        }

        public override bool NotAttachmentsUser(int userID, int bookID)
        {
            UserBook userBook = UserBook.Find(x => x.User.ID == userID && x.Book.ID == bookID);
            if (userBook != null)
            {
                userBook.DateTimeEnd = DateTime.Now.Date;
                return true;
            }

            return false;
        }
    }
}
