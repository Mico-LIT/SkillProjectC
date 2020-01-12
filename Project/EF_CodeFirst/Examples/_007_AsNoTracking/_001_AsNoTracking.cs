using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Examples._007_AsNoTracking
{
    public class _001_AsNoTracking
    {
        /// <summary>
        /// Когда контекст данных извлекает данные из базы данных, Entity Framework помещает извлеченные объекты в кэш и отслеживает изменения,
        /// которые происходят с этими объектами вплоть до использования метода SaveChanges(),
        /// который фиксирует все изменения в базе данных. Но нам не всегда необходимо отслеживать изменения. Например, нам надо просто вывести данные для просмотра.
        /// </summary>
        public _001_AsNoTracking()
        {
            using (var db = new TrainintDBContext())
            {
                var user = db.Users.AsNoTracking().FirstOrDefault();
                //var user = db.Users.FirstOrDefault();

                foreach (var item in db.Users.ToList())
                {
                    Console.WriteLine("Name {1} Age {0}", item.Age, item.Name);
                }

                user.Age = 9999;
                db.SaveChanges();

                foreach (var item in db.Users.ToList())
                {
                    Console.WriteLine("Name {1} Age {0}", item.Age, item.Name);
                }

            }
        }
    }
}
