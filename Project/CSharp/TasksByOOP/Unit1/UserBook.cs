using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.TasksByOOP.Unit1
{
   internal class UserBook
    {
        public int ID { get; set; }
        public Book Book { get; set; }
        public User User { get; set; }
        public DateTime DateTimeStart { get; set; }
        public DateTime DateTimeEnd { get; set; }
    }
}
