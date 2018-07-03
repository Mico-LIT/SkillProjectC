using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.SystemCollection._SortedList
{
    class SortedListExample3
    {
        public SortedListExample3()
        {
            var sort = new SortedList<string,string>();

            sort["First"] = "1st"; // 1
            sort["Second"] = "2nd";// 4
            sort["Third"] = "3rd"; // 5
            sort["Fourth"] = "4th";// 3
            sort["fourth"] = "4th";// 2

            foreach (KeyValuePair<string,string> item in sort)
            {
                Console.WriteLine($"[{item.Key}] = {item.Value}");
                //Console.WriteLine(item.GetType());
            }

            Console.ReadLine();
        }
    }
}
