using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.Queue
{
    // Двусторонняя очередь
    class _002_DeQueue
    {
        class DeQue<T>
        {
            LinkedList<T> _items = new LinkedList<T>();
            public int Count => _items.Count;

            public void EnqueueFirst(T value) 
            {
                _items.AddFirst(value);
            }

            public void EnqueueLast(T value) 
            {
                _items.AddLast(value);
            }

            public T DequeueFirst() 
            {
                if (Count == 0)
                    throw new InvalidOperationException();

                var result = _items.First.Value;
                _items.RemoveFirst();
                return result;
            }

            public T DequeueLast() 
            {
                if (Count == 0)
                    throw new InvalidOperationException();

                var result = _items.Last.Value;
                _items.RemoveLast();
                return result;
            }

            public T PeekFirst() 
            {
                if (Count == 0)
                    throw new InvalidOperationException();

                return _items.First.Value;
            }

            public T PeekLast()
            {
                if (Count == 0)
                    throw new InvalidOperationException();

                return _items.Last.Value;
            }
        }


        public _002_DeQueue()
        {
            DeQue<int> instance = new DeQue<int>();


            instance.EnqueueLast(1);
            instance.EnqueueLast(2);
            instance.EnqueueLast(3);
            instance.EnqueueLast(4);

            instance.EnqueueFirst(7);
            instance.EnqueueFirst(8);

            Console.WriteLine(instance.PeekFirst());
            Console.WriteLine(instance.PeekLast());

        }
    }
}
