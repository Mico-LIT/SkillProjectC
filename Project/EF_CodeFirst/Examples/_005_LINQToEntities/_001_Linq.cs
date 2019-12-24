using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Examples._005_LINQToEntities
{
    public class _001_Linq
    {
        public _001_Linq()
        {
            using (var db = new TrainintDBContext())
            {
                var items = (from x in db.Users where x.Age > 3 select x).ToList();

                // Методы расширения
                items = db.Users.Where(x => x.Age > 3).ToList();

                // Различие между Linq to Entities и Linq to Objects
                items = db.Users.Where(x => x.Age > 3).ToList().Where(y => y.Id == 2).ToList();

                var item = db.Users.FirstOrDefault(x => x.Id == 12);

                var user = db.Users.Select(x => new
                {
                    NameNew = x.Name,
                    AgeNew = x.Age
                });

                // OrderBy
                var userOrderByDescending = from x in db.Users orderby x.Age descending select x;
                var userOrderByDescendingExtension = db.Users.OrderByDescending(x => x.Age).ToList();
                //

                // Join
                var userJoin = from x in db.Users
                    join y in db.UserDocument on x.Id equals y.UserId
                    select new
                    {
                        UserName = x.Name,
                        DocumentDescription = y.Description
                    };
                //

                // groupBy
                var userGroupby = from x in db.Users group x by x.Age;
                //var userGroupby = db.Users.GroupBy(x => x.Age);

                foreach (var elements in userGroupby)
                {
                    Console.WriteLine(elements.Key);
                    foreach (var value in elements)
                        Console.WriteLine(value);
                }

                //

                // Union
                var usersUnion = db.Users.Where(x => x.Age < 10)
                    .Union(db.Users.Where(x => x.Name.Contains("Саша")));
                //

                // Intersect
                var usersIntersect = db.Users.Where(x => x.Age < 10)
                    .Intersect(db.Users.Where(x => x.Name.Contains("Саша")));
                //

                // Except
                var user1 = db.Users.Where(x => x.Age < 10);
                var user2 = db.Users.Where(x => x.Name.Contains("Саша"));

                var userResult = user1.Except(user2);
                //
            }
        }
    }
}
