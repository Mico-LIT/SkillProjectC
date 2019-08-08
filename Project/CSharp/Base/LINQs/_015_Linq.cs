using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// into подобно let
/// </summary>
namespace CSharp.Base.LINQs
{
    class _015_Linq
    {
        public _015_Linq()
        {
            int[] i = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var query = from x in i
                        group x by x % 2 into tmp
                        //where tmp.Key == 0
                        select new
                        {
                            tmp.Key,
                            Count = tmp.Count(),
                            GroupValues = tmp
                        };

            foreach (var item in query)
            {
                Console.WriteLine("Count " + item.Count);
                Console.WriteLine("Key: " + item.Key);

                Console.Write("{" + string.Join(",", item.GroupValues) + "}");
                Console.WriteLine("\n");
            }
        }
    }
}
