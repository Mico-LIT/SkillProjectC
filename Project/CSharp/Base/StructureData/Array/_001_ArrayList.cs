using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.Array
{
    class _001_ArrayList
    {
        class ArrayList<T> : IEnumerable<T>
        {
            T[] _items;
            public int Count { get; private set; }
            public T this[int index]
            {
                get
                {
                    if (index > Count)
                        throw new IndexOutOfRangeException();

                    return _items[index];
                }
                set
                {
                    if (index > Count)
                        throw new IndexOutOfRangeException();

                    _items[index] = value;
                }
            }

            public ArrayList() : this(0)
            {
            }

            public ArrayList(int length)
            {
                if (length < 0)
                    throw new ArgumentException("length < 0");

                _items = new T[length];
            }

            public ArrayList(ICollection<T> items)
            {
                var index = 0;
                _items = new T[items.Count];

                foreach (var item in items)
                {
                    _items[index++] = item;
                    Count++;
                }
            }

            public void Add(T item)
            {
                if (this.Count == _items.Length)
                {
                    GrowArray();
                }

                _items[Count++] = item;
            }

            public void RemoveAt(int index)
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException();

                var shiftIndex = index + 1;
                // Если удаляется не последний элемент
                if (shiftIndex < Count)
                    System.Array.Copy(_items, shiftIndex, _items, index, Count - shiftIndex);

                Count--;
            }

            public bool Remove(T item)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (_items.Equals(item))
                    {
                        RemoveAt(i);
                        return true;
                    }
                }
                return false;
            }

            public void Insert(T item, int index)
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException();

                if (_items.Length == Count)
                    GrowArray();

                System.Array.Copy(_items, index, _items, index + 1, Count - index);

                _items[index] = item;
                Count++;
            }

            void GrowArray()
            {
                var arrayLength = _items.Length == 0 ? 4 : _items.Length << 1;
                var newArray = new T[arrayLength];

                _items.CopyTo(newArray, 0);
                _items = newArray;
            }

            public int IndexOf(T item)
            {
                for (int i = 0; i < Count; i++)
                {
                    if (_items.Equals(item))
                        return i;
                }

                return -1;
            }

            public bool Contains(T item)
            {
                return this.IndexOf(item) != -1;
            }

            public IEnumerator GetEnumerator()
            {
                for (int i = 0; i < this.Count; i++)
                {
                    yield return _items[i];
                }
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                return (IEnumerator<T>)this.GetEnumerator();
            }
        }


        public _001_ArrayList()
        {
            var array = new ArrayList<int>();

            array.Add(1);
            array.Add(2);
            array.Add(3);
            array.Add(4);

            foreach (var item in array)
                Console.WriteLine(item);
            Console.WriteLine("");
            array.RemoveAt(3);
            array.RemoveAt(2);
            array.RemoveAt(1);

            foreach (var item in array)
                Console.WriteLine(item);
            Console.WriteLine("");

            array.Add(11);

            foreach (var item in array)
                Console.WriteLine(item);
            Console.WriteLine("");

            array.Insert(10, 1);

            foreach (var item in array)
                Console.WriteLine(item);
            Console.WriteLine("");


        }
    }
}
