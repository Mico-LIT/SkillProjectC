using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Collections
{
    class Collections4
    {
        public Collections4()
        {
            Dictionary<int, string> dc = new Dictionary<int, string>();
            dc.Add(1,"Russia");
            dc.Add(2, "USA");

            foreach (KeyValuePair<int,string> item in dc)
            {
                Console.WriteLine(item.Key + ' '+ item.Value);
            }

            //foreach (var item in dc.Keys)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var item in dc.Values)
            //{
            //    Console.WriteLine(item);
            //}

            Console.WriteLine(dc[1]);
            dc.Remove(1);
            
        }
    }
}
