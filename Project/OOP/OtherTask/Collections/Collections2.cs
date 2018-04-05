using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Collections
{
    class Collections2
    {
        public Collections2()
        {
            //Dequeue: извлекает и возвращает первый элемент очереди
            //Enqueue: добавляет элемент в конец очереди
            //Peek: просто возвращает первый элемент из начала очереди без его удаления

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            
            Console.WriteLine(queue.Peek());
            Console.WriteLine(queue.Dequeue());

            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
