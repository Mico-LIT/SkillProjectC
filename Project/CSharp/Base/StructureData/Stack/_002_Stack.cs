using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.Stack
{
    class _002_Stack
    {
        public _002_Stack()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7 };

            //Constructor
            Stack<int> instance1 = new Stack<int>();
            Stack<int> instance2 = new Stack<int>(10);
            Stack<int> instance3 = new Stack<int>(arr);

            Console.WriteLine("{0}. Count {1}", nameof(instance1), instance1.Count);
            Console.WriteLine("{0}. Count {1}", nameof(instance2), instance2.Count);
            Console.WriteLine("{0}. Count {1}", nameof(instance3), instance3.Count);
            // Methods

            instance1.Push(1);
            instance1.Push(2);
            instance1.Push(3);
            instance1.Push(4);

            instance1.Pop();

            Console.WriteLine("Peek {0}", instance1.Peek());
            Console.WriteLine("Contains 2 = {0}", instance1.Contains(2));

            Console.WriteLine(new string('_', 15));
            int[] myarr = instance1.ToArray();

            for (int i = 0; i < myarr.Length; i++)
            {
                Console.WriteLine(myarr[i]);
            }

            Console.WriteLine(new string('_', 15));
            myarr = new int[10];

            instance1.CopyTo(myarr, 3);

            for (int i = 0; i < myarr.Length; i++)
            {
                Console.WriteLine(myarr[i]);
            }

            instance1.Clear();
            instance1.Peek();

        }
    }
}
