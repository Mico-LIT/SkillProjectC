using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.SystemCollection._Queue
{
    class QueueDemo
    {
        public QueueDemo()
        {
            var queue = new Queue();
            queue.Enqueue("An item");           //Enqueue - Добавляет эл в конец очереди
            Console.WriteLine(queue.Dequeue()); //Dequeue - Возвращает первый элемент очереди, удаляя его

            Console.ReadLine();
        }
    }
}
