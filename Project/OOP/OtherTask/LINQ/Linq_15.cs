using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// into подобно let
/// </summary>
namespace OOP.OtherTask.LINQ
{
    class Linq_15
    {
        public Linq_15()
        {
            int[] i = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var query = from x in i
                        group x by x % 2 into tmp
                        where tmp.Key == 0
                        select new { tmp.Key, Count=tmp.Count(), Group=tmp };

            //var query = from x in i
            //            group x by x % 2 into tmp
            //            select new { tmp.Key, Count = tmp.Count(), Group = tmp };

            foreach (var item in query)
            {
                Console.WriteLine(item.Count);
                Console.WriteLine(item.Key);
                foreach (var item2 in item.Group) Console.WriteLine(item);
            }
        }
    }
}
