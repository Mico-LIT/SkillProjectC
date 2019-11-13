using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_CodeFirst.Models.User;

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

                db.Airplanes.Add(new Airplane()
                {
                    Name = "123",
                    Year = 123
                });

                db.SaveChanges();
            }
        }
    }
}
