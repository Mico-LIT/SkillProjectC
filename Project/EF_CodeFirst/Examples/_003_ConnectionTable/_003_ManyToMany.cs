using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_CodeFirst.Models.User;

namespace EF_CodeFirst.Examples._003_ConnectionTable
{
    public class _003_ManyToMany
    {
        public _003_ManyToMany()
        {
            Init();
        }

        void Init()
        {
            using (var db = new TrainintDBContext())
            {
                var user = db.Users.FirstOrDefault();

                PrintConsole(user);

                if (user != null)
                {
                    var phoneOne = new Phone() { Number = "92311111" };
                    var phoneTwo = new Phone() { Number = "92322222" };

                    db.Phones.Add(phoneOne);
                    db.Phones.Add(phoneTwo);

                    user.Phones.Add(phoneOne);
                    user.Phones.Add(phoneTwo);

                    db.SaveChanges();
                }

                user = db.Users.FirstOrDefault(x => x.Id == user.Id);
                PrintConsole(user);
            }
        }

        void PrintConsole(User user)
        {

            Console.WriteLine($"UserID {user.Id} Age {user.Age} Name {user.Name}");
            Console.WriteLine($"Phones:");

            if (user.Phones != null)
                foreach (var phone in user.Phones)
                    Console.WriteLine(phone.Number);

            Console.WriteLine(new string('_', 20));
        }
    }
}
