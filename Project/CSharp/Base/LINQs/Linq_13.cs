using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.LINQs
{
    class Linq_13
    {
        public Linq_13()
        {
            int[] i = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            var query = from x in i
                        group x by x % 4;

            foreach (var item in query)
            {
                Console.WriteLine($"MOD {item.Key}");

                foreach (var item2 in item)
                {
                    Console.WriteLine(item2);
                }
            }

            Console.ReadLine();
        }
    }
}
