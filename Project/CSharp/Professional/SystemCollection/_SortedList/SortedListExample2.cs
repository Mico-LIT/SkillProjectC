using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.SystemCollection._SortedList
{
    class SortedListExample2
    {
        class DescendingComparer : IComparer
        {
            readonly CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();
            public int Compare(object x, object y)
            {
                return comparer.Compare(x, y);
            }
        }
        public SortedListExample2()
        {
            var sort = new SortedList(new DescendingComparer());
            //var sort = new SortedList();
            sort["First"] = "1st"; // 1
            sort["Second"] = "2nd";// 4
            sort["Third"] = "3rd"; // 5
            sort["Fourth"] = "4th";// 3
            sort["fourth"] = "4th";// 2

            foreach (DictionaryEntry item in sort)
            {
                Console.WriteLine($"[{item.Key}] = {item.Value}");
                //Console.WriteLine(item.GetType());
            }

            Console.ReadLine();
        }
    }
}
