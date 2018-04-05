using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Collections
{
    class Collections1
    {
        public Collections1()
        {
            ArrayList arr = new ArrayList();
            arr.Add(1.2);
            arr.Add(4);
            arr.AddRange(new string[] { "aaa","ddd"});

            foreach (object item in arr)
            {
                Console.WriteLine(item);
            }

            arr.RemoveAt(0);

            arr.Reverse();

            Console.WriteLine($"{arr[0]}");

            for (int i = 0; i < arr.Count; i++)
            {
                Console.WriteLine(arr[i]);
            }

            Console.ReadLine();
        }
    }
}
