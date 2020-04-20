using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.LinkedList
{
    class _003_LinkedListNode
    {
        class LinkedListNode<T>
        {
            public LinkedListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; internal set; }
            public LinkedListNode<T> Next { get; internal set; }
        }

        class LinkedList<T> : IEnumerable<T>
        {
            LinkedListNode<T> _head;
            LinkedListNode<T> _tail;

            public int Count { get; private set; }

            public void Add(T value)
            {
                if (value == null)
                    throw new NullReferenceException();

                var node = new LinkedListNode<T>(value);

                if (_head == null)
                {
                    _head = _tail = node;
                }
                else
                {
                    _tail = _tail.Next = node;
                }

                Count++;
            }

            public bool Remove(T item)
            {
                if (item == null)
                    throw new NullReferenceException();

                if (_head == null)
                    return false;

                LinkedListNode<T> previous = null;
                LinkedListNode<T> current = _head;

                while (current != null)
                {
                    if (current.Value.Equals(item))
                    {
                        if (previous != null)
                        {
                            previous.Next = current.Next;

                            if (current.Next == null)
                                _tail = previous;
                        }
                        else
                        {
                            _head = current.Next;

                            if (_head == null)
                                _tail = null;
                        }

                        Count--;
                        return true;
                    }

                    previous = current;
                    current = current.Next;
                }

                return false;
            }

            public bool Contains(T item)
            {
                if (item == null)
                    throw new NullReferenceException();

                if (_head == null)
                    return false;

                LinkedListNode<T> current = _head;

                while(current != null)
                {
                    if (current.Value.Equals(item))
                        return true;

                    current = current.Next;
                }

                return false;
            }

            public void Clear()
            {
                _tail = _head = null;
                Count = 0;
            }

            public void CopyTo(T[] arr, int arrIndex)
            {
                var current = _head;

                while (current != null)
                {
                    arr[arrIndex++] = current.Value;
                    current = current.Next;
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                var current = _head;

                while (current != null)
                {
                    yield return current.Value;
                    current = current.Next;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }


        public _003_LinkedListNode()
        {
            var linkedList = new LinkedList<int>();

            linkedList.Add(12);
            linkedList.Add(11);
            linkedList.Add(23);
            linkedList.Add(88);

            Display(linkedList);
            Console.WriteLine("Contains item = 11 : {0}", linkedList.Contains(11));

            linkedList.Remove(11);
            Display(linkedList);

            int[] arr = new int[4];

            linkedList.CopyTo(arr, 0);

            foreach (var item in arr)
                Console.Write(" {0}",item);

            linkedList.Clear();
            Display(linkedList);


            Console.Read();
        }

        void Display<T>(LinkedList<T> nodes)
        {
            foreach (var item in nodes)
            {
                Console.WriteLine(item);
            }
        }
    }
}
