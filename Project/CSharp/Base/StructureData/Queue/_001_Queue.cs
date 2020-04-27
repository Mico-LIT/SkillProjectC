using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.Queue
{
    // Реализация на основе 2-х связного списка
    class _001_Queue
    {
        class Queue<T>
        {
            LinkedList<T> _items = new LinkedList<T>();
            public int Count => _items.Count;


            public void Enqueue(T item)
            {
                _items.AddFirst(item);
            }
            public T Dequeue()
            {
                if (Count == 0)
                    throw new InvalidOperationException("Queue empty");

                var result = _items.Last.Value;
                _items.RemoveLast();
                return result;

            }
            public T Peek()
            {
                if (Count == 0)
                    throw new InvalidOperationException("Queue empty");

                return _items.Last.Value;
            }
        }


        public _001_Queue()
        {
            Queue<int> instance = new Queue<int>();

            instance.Enqueue(1);
            instance.Enqueue(2);
            instance.Enqueue(3);
            instance.Enqueue(4);

            Console.WriteLine("Count elements in Queue {0}", instance.Count);
            Console.WriteLine("Peek {0}", instance.Peek());

            var firstElement = instance.Dequeue();

            Console.WriteLine("firstElement : {0}", firstElement);
            Console.WriteLine("Count elements in Queue {0}", instance.Count);
            Console.WriteLine("Peek : {0}", instance.Peek());
        }
    }
}
