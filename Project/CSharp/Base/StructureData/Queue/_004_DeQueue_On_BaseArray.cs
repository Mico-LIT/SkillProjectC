using System;

namespace CSharp.Base.StructureData.Queue
{
    //Двусвязная очередь на основе массива
    class _004_DeQueue_On_BaseArray
    {
        class DeQue<T>
        {
            T[] _items = new T[0];

            // Количество элементов в двусвязной очереди
            int _size = 0;
            // Указатель на первый элемент
            int _head = 0;
            // Указатель на последний элемент
            int _tail = -1;

            public int Count => _size;

            private void allocateNewArr(int startIndex, bool reduceLength = false)
            {
                int newLength;

                if (!reduceLength)
                    newLength = _size == 0 ? 4 : _size * 2;
                else
                    newLength = _size;

                T[] newArr = new T[newLength];

                if (_size > 0)
                {
                    var targetIndex = startIndex;

                    if (_tail < _head)
                    {
                        for (int i = _head; i < _items.Length; i++)
                        {
                            newArr[targetIndex] = _items[i];
                            targetIndex++;
                        }

                        for (int i = 0; i <= _tail; i++)
                        {
                            newArr[targetIndex] = _items[i];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        for (int i = _head; i <= _tail; i++)
                        {
                            newArr[targetIndex] = _items[i];
                            targetIndex++;
                        }
                    }

                    _head = startIndex;
                    _tail = targetIndex - 1;
                }
                else
                {
                    _head = 0;
                    _tail = -1;
                }

                _items = newArr;
            }

            public void EnqueueFirst(T item)
            {
                if (_items.Length == _size) allocateNewArr(1);

                if (_head > 0)
                    _head--;
                else
                    _head = _items.Length - 1;

                _items[_head] = item;
                _size++;
            }

            public void EnqueueLast(T item)
            {
                if (_items.Length == _size) allocateNewArr(0);

                if (_tail == _items.Length - 1)
                    _tail = 0;
                else
                    _tail++;

                _items[_tail] = item;
                _size++;
            }

            public T PeekFirst()
            {
                if (_size == 0)
                    throw new InvalidOperationException("Queue empty");

                return _items[_head];
            }

            public T PeekLast()
            {
                if (_size == 0)
                    throw new InvalidOperationException("Queue empty");

                return _items[_tail];
            }

            public T DeQueueFirst()
            {
                if (_size == 0) throw new InvalidOperationException("Queue empty");

                if ((_items.Length / 2) == _size) allocateNewArr(0, true);

                if (_head >= _items.Length) _head = 0;

                _size--;
                return _items[_head++];
            }

            public T DeQueueLast()
            {
                if (_size == 0) throw new InvalidOperationException("Queue empty");

                if ((_items.Length / 2) == _size) allocateNewArr(0, true);

                if (_tail <= 0) _tail = _items.Length - 1;

                _size--;
                return _items[_tail--];
            }
        }

        public _004_DeQueue_On_BaseArray()
        {
            DeQue<int> instance = new DeQue<int>();
            bool forTest = true;

            if (forTest)
            {
                instance.EnqueueLast(1);
                instance.EnqueueLast(2);
                instance.EnqueueLast(3);
                instance.EnqueueLast(4);
                instance.EnqueueLast(5);
                instance.EnqueueLast(6);
                instance.EnqueueLast(7);
                instance.EnqueueLast(8);
                instance.EnqueueLast(9);
                instance.EnqueueLast(10);

                instance.EnqueueFirst(11);
                instance.EnqueueFirst(12);
                instance.EnqueueFirst(13);
                instance.EnqueueFirst(14);
                instance.EnqueueFirst(15);
                instance.EnqueueFirst(16);
                instance.EnqueueFirst(17);
                instance.EnqueueFirst(18);
                instance.EnqueueFirst(19);
                instance.EnqueueFirst(20);

                for (int i = 0; i < 10; i++)
                    Console.WriteLine("DeQueueFirst {0}", instance.DeQueueFirst());

                for (int i = 0; i < 10; i++)
                    Console.WriteLine("_____DeQueueLast {0}", instance.DeQueueLast());

                Console.WriteLine("PeekFirst {0}", instance.PeekFirst());
            }
            else
            {
                instance.EnqueueFirst(6);
                instance.EnqueueFirst(7);
                instance.EnqueueFirst(8);

                Console.WriteLine("PeekFirst {0}", instance.PeekFirst());

                instance.EnqueueFirst(6);
                instance.EnqueueFirst(7);
                instance.EnqueueFirst(8);

                Console.WriteLine("PeekFirst {0}", instance.PeekFirst());
                Console.WriteLine("PeekLast {0}", instance.PeekLast());
            }
        }
    }
}
