using EF_CodeFirst.Models.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Examples._003_ConnectionTable
{
    public class _002_OneToMany
    {
        public _002_OneToMany()
        {
            this.Init();

            using (var db = new TrainintDBContext())
            {
                var users = db.Users.Include("Documents").ToList();
                PrintConsole(users);

                var userFirst = users.FirstOrDefault();
                userFirst.Name = "Test";
                userFirst.Age = 100;

                db.Entry(userFirst).State = EntityState.Modified;
                db.SaveChanges();

                PrintConsole(db.Users.Include("Documents").ToList());
            }
        }

        void Init()
        {
            using (var db = new TrainintDBContext())
            {
                db.UserDocument.Add(new Models.User.UserDocument()
                {
                    UserId = 1,
                    Description = "85455688",
                    Type = UserDocument.TypeDocument.Passport
                });

                db.SaveChanges();
            }
        }

        void PrintConsole(List<User> users)
        {
            foreach (var user in users)
            {
                Console.WriteLine($"UserID {user.Id} Age {user.Age} Name {user.Name}");
                Console.WriteLine($"User docs");

                foreach (var doc in user.Documents)
                    Console.WriteLine(doc.Type.ToString());
            }
            Console.WriteLine(new string('_',20));
        }
    }
}
