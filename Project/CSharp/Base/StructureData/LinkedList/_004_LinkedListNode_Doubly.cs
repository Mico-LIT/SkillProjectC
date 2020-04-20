using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.LinkedList
{
    class _004_LinkedListNode_Doubly
    {
        class LinkedListNode<T>
        {
            public LinkedListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; set; }
            public LinkedListNode<T> Next { get; set; }
            public LinkedListNode<T> Previous { get; set; }
        }

        class LinkedList<T> : IEnumerable<T> where T : struct
        {
            LinkedListNode<T> _head;
            LinkedListNode<T> _tail;

            public int Count { get; private set; }

            public void AddFirst(T item)
            {
                LinkedListNode<T> node = new LinkedListNode<T>(item);

                LinkedListNode<T> tmp = _head;
                _head = node;
                _head.Next = tmp;

                if (Count == 0)
                    _tail = node;
                else
                    tmp.Previous = _head;

                Count++;
            }

            public void AddLast(T item)
            {
                LinkedListNode<T> node = new LinkedListNode<T>(item);

                if (Count == 0)
                {
                    _head = node;
                }
                else
                {
                    _tail.Next = node;
                    node.Previous = _tail;
                }

                _tail = node;
                Count++;
            }

            public bool Remove(T item)
            {
                LinkedListNode<T> previous = null;
                LinkedListNode<T> current = _head;

                while (current != null)
                {
                    if (current.Value.Equals(item))
                    {
                        if (previous == null)
                        {
                            RemoveFirst();
                        }
                        else
                        {
                            previous.Next = current.Next;

                            if (current.Next == null)
                                _tail = previous;
                            else
                                current.Next.Previous = previous;

                            Count--;
                        }

                        return true;
                    }

                    previous = current;
                    current = current.Next;
                }

                return false;
            }

            public bool RemoveFirst()
            {
                if (Count != 0)
                {
                    _head = _head.Next;
                    Count--;

                    if (Count == 0)
                        _tail = _head = null;
                    else
                        _head.Previous = null;

                    return true;
                }

                return false;
            }

            public bool RemoveLast()
            {
                if (Count != 0)
                {
                    if (Count == 1)
                        _tail = _head = null;

                    else
                    {
                        _tail = _tail.Previous;
                        _tail.Next = null;
                    }

                    Count--;
                }

                return false;
            }

            public bool Contains(T item)
            {
                LinkedListNode<T> current = _head;

                while (current != null)
                {
                    if (current.Value.Equals(item))
                        return true;

                    current = current.Next;
                }

                return false;
            }

            public void Clear()
            {
                _head = _tail = null;
                Count = 0;
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
                return this.GetEnumerator();
            }
        }

        public _004_LinkedListNode_Doubly()
        {
            var linkedList = new LinkedList<int>();
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddFirst(4);
            linkedList.AddFirst(5);
            linkedList.AddFirst(6);

            Display(linkedList);

            linkedList.Remove(5);

            Display(linkedList);
            linkedList.RemoveLast();
            Display(linkedList);
        }

        private void Display(LinkedList<int> linkedList)
        {
            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine();
        }
    }
}
