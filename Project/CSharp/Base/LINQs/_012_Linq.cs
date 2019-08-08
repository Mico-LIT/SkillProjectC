using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.LINQs
{
    class _012_Linq
    {
        public _012_Linq()
        {
            var query = from x in Enumerable.Range(1, 10)
                        let i = Enumerable.Range(1, 10)
                        from y in i
                        select new { X = x, Y = y, Product = x * y };
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
