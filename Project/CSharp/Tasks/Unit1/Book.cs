using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Tasks.Unit1
{
   public class Book
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CountPage { get; set; }
        public int Years { get; set; }
        public string BookAuthor { get; set; }
        public BookType Type { get; set; }
    }
   public enum BookType
    {
        журнал = 1,
        научная_литература,
        сказки

    }
}
