using CSharp.Base.Threading.Synchronization;
using CSharp.Base.Threading.TPL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            private void allocateNewArr(int startIndex)
            {
                int newLength = _size == 0 ? 4 : _size * 2;

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
                if (_items.Length == _size)
                {
                    allocateNewArr(1);
                }

                if (_head > 0)
                {
                    _head--;
                }
                else
                {
                    _head = _items.Length - 1;
                }

                _items[_head] = item;
                _size++;

            }

            public void EnqueueLast(T item)
            {
                if (_items.Length == _size)
                {
                    allocateNewArr(0);
                }

                if (_tail == _items.Length - 1)
                {
                    _tail = 0;
                }
                else
                {
                    _tail++;
                }

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

            // TODO _004_DeQueue_On_BaseArray
            // Урок 3. Стеки и очереди -> time 40:38
            // DeQueueFirst and DeQueueLast
            public T DeQueueFirst()
            {
                if (_size == 0)
                    throw new InvalidOperationException("Queue empty");

                var result = _items[_head];

                System.Array.Copy(_items, _head + 1, _items, _head + 1, (_items.Length - 1) - _head);
                _size--;
                _head = 1;

                return result;
            }

            //public T DeQueueLast()
            //{
            //    return null;
            //}
        }


        public _004_DeQueue_On_BaseArray()
        {
            DeQue<int> instance = new DeQue<int>();

            instance.EnqueueLast(1);
            instance.EnqueueLast(2);
            //instance.EnqueueLast(3);

            Console.WriteLine("PeekFirst {0}", instance.PeekFirst());


            Console.WriteLine("PeekFirst {0}", instance.PeekFirst());


            instance.EnqueueFirst(6);
            instance.EnqueueFirst(7);
            instance.EnqueueFirst(8);

            Console.WriteLine("PeekFirst {0}", instance.PeekFirst());
            Console.WriteLine("PeekLast {0}", instance.PeekLast());
        }
    }

    class Class1
    {
        public class Deque<T>
        {
            T[] _items = new T[0];

            // Количество элементов в двусвязной очереди     
            int _size = 0;

            // Указатель на первый (самый старый) элемент очереди.     
            int _head = 0;

            // Указатель на последний (новый) элемент очереди.     
            int _tail = -1;

            #region Метод увеличивает внутренний массива

            private void allocateNewArray(int startingIndex)
            {

                // начальный размер массива равен 4, при увеличение массива размер удваивается.

                int newLength = (_size == 0) ? 4 : _size * 2;

                T[] newArray = new T[newLength];

                if (_size > 0)
                {
                    int targetIndex = startingIndex;

                    // Копирование содержимого ...         
                    // Если не было обхода массива индексами, то копирование элементов.         
                    // в ином случае копирование с указателя head до конца массива end, а затем от 0 до tail.  
                    // Если указатель tail меньше чем head, осуществить им обход массива.         

                    if (_tail < _head)
                    {
                        // Копирование от _items[head].._items[end] -> newArray[0]..newArray[N].             
                        for (int index = _head; index < _items.Length; index++)
                        {

                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }

                        // Копирование от _items[0].._items[tail] -> newArray[N+1]..             

                        for (int index = 0; index <= _tail; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                    }
                    else
                    {
                        // Копировать от _items[head].._items[tail] -> newArray[0]..newArray[N]             
                        for (int index = _head; index <= _tail; index++)
                        {
                            newArray[targetIndex] = _items[index];
                            targetIndex++;
                        }
                    }

                    _head = startingIndex;
                    _tail = targetIndex - 1;


                }
                else
                {    // Если массив пустой.         
                    _head = 0;
                    _tail = -1;
                }

                _items = newArray;
            }

            #endregion

            #region Метод добавляет новый элемент в начало очереди

            public void EnqueueFirst(T item)
            {

                // Увеличение размера внутреннего массива
                if (_items.Length == _size)
                {

                    allocateNewArray(1);

                }

                if (_head > 0)
                {
                    _head--;
                }
                else
                {
                    // Оборот вокруг конца массива         
                    _head = _items.Length - 1;
                }

                _items[_head] = item;

                _size++;
            }

            #endregion

            #region Метод добавляет новый элемент в конец очереди

            public void EnqueueLast(T item)
            {

                // Размер массива нужно увеличить 

                if (_items.Length == _size)
                {
                    allocateNewArray(0);
                }

                // Обход массива

                if (_tail == _items.Length - 1)
                {
                    _tail = 0;
                }

                else
                {
                    _tail++;
                }

                _items[_tail] = item;
                _size++;
            }

            #endregion

            #region  DequeueFirst и DequeueLast

            //public T DequeueFirst()
            //{

            //}

            //public T DequeueLast()
            //{

            //}

            #endregion

            #region Метод возвращает первый элемент в очереди

            public T PeekFirst()
            {
                if (_size == 0)
                {
                    throw new InvalidOperationException("Двусвязная очередь пуста");
                }

                return _items[_head];
            }

            #endregion

            #region Метод возвращает последний элемент в очереди

            public T PeekLast()
            {
                if (_size == 0)
                {
                    throw new InvalidOperationException("Двусвязная очередь пуста");
                }

                return _items[_tail];
            }

            #endregion

            #region Свойство содержит количество элементов в двусвязной очереди

            public int Count
            {
                get
                {
                    return _size;
                }
            }

            #endregion
        }
        public Class1()
        {
            Deque<int> instanse = new Deque<int>();


            // First -> указатель на начало очереди
            // Last  -> указатель на конец очереди

            instanse.EnqueueLast(1);     // -> -> -> -> -> -> ->  
            instanse.EnqueueLast(2);     // Двусвязная очередь:  3 -> 2 -> 1
            instanse.EnqueueLast(3);     // -> -> -> -> -> -> ->

            instanse.EnqueueFirst(4);    // -> -> -> -> -> -> ->
            instanse.EnqueueFirst(5);    // Двусвязная очередь:  3 -> 2 -> 1 -> 4 -> 5 -> 6
            instanse.EnqueueFirst(6);    // -> -> -> -> -> -> ->


            Console.WriteLine("Первый элемент в очереди: {0}", instanse.PeekFirst());
            Console.WriteLine("Последний элемент в очереди: {0}", instanse.PeekLast());
        }
    }
}
