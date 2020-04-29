using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.Queue
{
    class _003_Queue
    {
        public _003_Queue()
        {
            Console.SetWindowSize(50, 30);

            int[] arr = new int[] { 1, 2, 3, 4, 5, 6, 7 };

            Queue<int> instance1 = new Queue<int>();
            Queue<int> instance2 = new Queue<int>(5);
            Queue<int> instance3 = new Queue<int>(arr);

            Console.WriteLine("{0}. Count {1}", nameof(instance1), instance1.Count);
            Console.WriteLine("{0}. Count {1}", nameof(instance2), instance2.Count);
            Console.WriteLine("{0}. Count {1}", nameof(instance3), instance3.Count);

            instance1.Enqueue(1);
            instance1.Enqueue(2);
            instance1.Enqueue(3);
            instance1.Enqueue(4);
            instance1.Enqueue(5);

            Console.WriteLine("Peek {0}", instance1.Peek());
            instance1.Dequeue();
            Console.WriteLine("Peek {0}", instance1.Peek());

            Console.WriteLine("Contains 2 = {0}", instance1.Contains(2));


            Console.WriteLine(new string('_', 15));

            int[] myArr = instance1.ToArray();

            for (int i = 0; i < myArr.Length; i++)
                Console.WriteLine("{0}", myArr[i]);

            myArr = new int[10];
            instance1.CopyTo(myArr, 3);

            Console.WriteLine(new string('_', 15));

            for (int i = 0; i < myArr.Length; i++)
                Console.WriteLine("{0}", myArr[i]);

            instance1.Clear();
            //instance1.Peek();

        }
    }
}
