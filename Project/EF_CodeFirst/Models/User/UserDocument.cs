using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Models.User
{
    public class UserDocument
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public TypeDocument Type { get; set; }
        public string Description { get; set; }

        public User User { get; set; }

        public enum TypeDocument
        {
            Passport,
            INN
        }
    }
}
