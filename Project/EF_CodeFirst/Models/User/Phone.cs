using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Models.User
{
    public class Phone
    {
        public int Id { get; set; }
        public string Number { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
