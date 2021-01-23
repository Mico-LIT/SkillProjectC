using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.TasksByOOP.Unit1
{
    internal abstract class libraryBase
    {
        protected List<User> User { get; set; } = new List<User>();
        protected List<Book> Book { get; set; } = new List<Book>();
        protected List<UserBook> UserBook { get; set; } = new List<UserBook>();
        public abstract void AddBook(Book bk);
        public abstract bool DeleteBook(int id);
        public abstract Book FindBookID(int id);
        public abstract bool AddUser(User user);
        public abstract bool DeleteUser(int userID);
        public abstract bool AttachmentsUser(int userID, int bookID);
        public abstract bool NotAttachmentsUser(int userID, int bookID);
    }
}
