using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new UserContext())
            {
                db.Users.Add(new Models.User.UserTMP()
                {
                    Age = 12,
                    Name = "Jon"
                });

                db.SaveChanges();
            }
        }
    }
}
