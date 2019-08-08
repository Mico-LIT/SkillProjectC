using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.LINQs
{
    class _016_Linq
    {
        public _016_Linq()
        {
            int[] _x = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int[] _y = { 1, 3, 5, 6, 7, 9 };

            var tmps = from x in _x
                      join y in _y on x equals y into groupZ

                      from r in groupZ.DefaultIfEmpty()
                      select new
                      {
                          r
                      };

            foreach (var item in tmps)
                Console.WriteLine(item);

        }
    }
}
