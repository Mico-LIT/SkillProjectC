using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.HashSet
{
    class _001_Set
    {
        class Set<T> : IEnumerable<T> where T : IComparable<T>
        {
            List<T> _items = new List<T>();

            public int Count => _items.Count;

            public Set() { }

            public Set(IEnumerable<T> items)
            {
                AddRange(items);
            }

            public void Remove(T item)
            {
                _items.Remove(item);
            }

            public bool Contains(T item)
            {
                return _items.Contains(item);
            }

            public void AddRange(IEnumerable<T> items)
            {
                foreach (T item in items)
                {
                    this.Add(item);
                }
            }

            public void Add(T value)
            {
                if (Contains(value))
                    throw new InvalidOperationException("Element in list exist  ");

                _items.Add(value);
            }


            public IEnumerator<T> GetEnumerator()
            {
                return _items.GetEnumerator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return _items.GetEnumerator();
            }


            // Объединение множеств
            public Set<T> Union(Set<T> other)
            {
                var tmp = new Set<T>(_items);

                foreach (var item in other._items)
                {
                    if (!tmp.Contains(item))
                        tmp.Add(item);
                }

                return tmp;
            }

            // Разность множеств
            public Set<T> Difference(Set<T> other)
            {
                var tmp = new Set<T>(_items);
                foreach (var item in other._items)
                    tmp.Remove(item);

                return tmp;
            }

            // Пересечение множеств
            public Set<T> Intersection(Set<T> other)
            {
                var tmp = new Set<T>();

                foreach (var item in other._items)
                {
                    if (this._items.Contains(item))
                        tmp.Add(item);
                }

                return tmp;
            }

            // Семметрическая разность множеств
            public Set<T> SymmetricDifference(Set<T> other)
            {
                var intersect = Intersection(other);
                var union = Union(other);
                return union.Difference(intersect);
            }

        }

        public _001_Set()
        {
            int[] arr = new int[] { 3, 4, 5, 6 };

            Set<int> instance1 = new Set<int>();
            Set<int> instance2 = new Set<int>(arr);
            Set<int> instance3 = new Set<int>();

            instance1.Add(1);
            instance1.Add(2);
            instance1.Add(3);
            instance1.Add(4);

            instance3 = instance1.SymmetricDifference(instance2);

            foreach (var item in instance3)
                Console.WriteLine(item);
        }
    }
}
