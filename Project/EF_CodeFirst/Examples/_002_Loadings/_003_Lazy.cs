using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Examples._002_Loadings
{
    /// <summary>
    /// Ленивая загрузка (Нужно указать в свойствах virtual)
    /// </summary>
    public class _003_Lazy
    {
        public _003_Lazy()
        {
            using (var db = new TrainintDBContext())
            {
                foreach (var user in db.Users.ToList())
                {
                    Console.WriteLine("User:"+user.Name);
                    Console.WriteLine("Docs:");
                    foreach (var document in user.Documents)
                    {
                        Console.WriteLine(document.Type.ToString());
                    }

                }

                foreach (var doc in db.UserDocument.ToList())
                {
                    Console.WriteLine($"{doc.User.Name} {doc.Type.ToString()}");
                }
            }
        }
    }
}
