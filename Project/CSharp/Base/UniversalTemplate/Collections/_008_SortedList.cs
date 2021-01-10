using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.Collections
{
    class _008_SortedList
    {
        public _008_SortedList()
        {    
            // Единственное отличие от Dictinary это SortedList использует меньше памяти
            SortedList<int, string> keyValuePairs = new SortedList<int, string>();

            //keyValuePairs.Add(2, "trr");
            keyValuePairs.Add(2, "trr");
            keyValuePairs.Add(4, "trr1");
            keyValuePairs.Add(1, "trr2");

            foreach (var item in keyValuePairs)
            {
                Console.WriteLine("Key:{0} Value:{1}", item.Key, item.Value);
            }
        }
    }
}
