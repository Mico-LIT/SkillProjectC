using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.SystemCollection._Queue
{
    class QueueDemo3
    {
        public QueueDemo3()
        {
            var queue = new Queue<string>();
            queue.Enqueue("First");
            queue.Enqueue("Secomd");
            queue.Enqueue("Third");
            queue.Enqueue("Fourth");

            object elem = queue.Peek(); // Посмотреть кто тут у нас
            Console.WriteLine(elem as string);

            if (elem is string)
            {
                Console.WriteLine(queue.Dequeue());
            }

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            Console.ReadLine();
        }
    }
}
