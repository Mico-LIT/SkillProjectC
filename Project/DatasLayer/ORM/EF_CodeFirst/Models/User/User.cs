using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Models.User
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        // Используется во избежании параллелизма 
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public UserProfile UserProfile { get; set; }

        public ICollection<UserDocument> Documents { get; set; }
        public virtual ICollection<Phone> Phones { get; set; }
    }
}
