using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.SystemCollection._Dictionary
{
    class DictionaryExample
    {
        public DictionaryExample()
        {
            var dict = new Dictionary<int, string>();
            dict[1] = "One";
            dict[2] = "Two";
            dict[2] = "Two1";
            dict[3] = "Three";
            string str = dict[3];

            foreach (KeyValuePair<int,string> item in dict)
            {
                Console.WriteLine($"{item.Key}  {item.Value}");
            }

            foreach (var item in dict.Values)
            {
                Console.WriteLine( item);
            }

            Console.ReadLine();
        }
    }
}
