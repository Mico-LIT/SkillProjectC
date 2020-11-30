using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.HashTable
{
    public class _002_HashTableArrayNode
    {
        public _002_HashTableArrayNode()
        {
            var instanse = new HashTableArrayNode<string, string>();

            instanse.Add("1", "2");
            instanse.Add("2", "4");
            instanse.Add("3", "3");

            instanse.Update("22", "22");

            if (instanse.TryGetValue("2", out var result))
                Console.WriteLine($"result: {result}");


            foreach (var item in instanse)
                Console.WriteLine(item);
        }

        public class HashTableArrayNode<TKey, TValue>
        {
            LinkedList<_001_HashTableNodePair<TKey, TValue>> _items;

            public void Add(TKey key, TValue value)
            {
                if (_items == null)
                {
                    _items = new LinkedList<_001_HashTableNodePair<TKey, TValue>>();
                }
                else
                {
                    foreach (var item in _items)
                    {
                        if (item.Key.Equals(key))
                            throw new ArgumentException("Key is exist");
                    }
                }

                _items.AddLast(new _001_HashTableNodePair<TKey, TValue>(key, value));
            }

            public void Update(TKey key, TValue value)
            {

                if (_items != null)
                {
                    foreach (_001_HashTableNodePair<TKey, TValue> item in _items)
                        if (item.Key.Equals(key))
                        {
                            item.Value = value;
                            return;
                        }

                    throw new ArgumentException("Key is exist");
                }
            }

            public bool TryGetValue(TKey key, out TValue value)
            {
                value = default;
                bool found = false;

                if (_items != null)
                {
                    foreach (_001_HashTableNodePair<TKey, TValue> pair in _items)
                        if (pair.Key.Equals(key))
                        {
                            value = pair.Value;
                            found = true;
                            break;
                        }
                }

                return found;
            }

            public bool Remove(TKey key)
            {
                bool removed = false;

                if (_items != null)
                {
                    var curr = _items.First;
                    while (curr != null)
                    {
                        if (curr.Value.Key.Equals(key))
                        {
                            _items.Remove(curr);
                            removed = true;
                            break;
                        }
                        curr = curr.Next;
                    }
                }

                return removed;
            }

            public void Clear()
            {
                if (_items != null)
                    _items.Clear();

            }

            public System.Collections.Generic.IEnumerator<TKey> GetEnumerator()
            {
                if (_items != null)
                {
                    foreach (_001_HashTableNodePair<TKey, TValue> node in _items)
                        yield return node.Key;
                }
            }


            public IEnumerable<_001_HashTableNodePair<TKey, TValue>> Items
            {
                get
                {
                    if (_items != null)
                    {
                        foreach (_001_HashTableNodePair<TKey, TValue> node in _items)
                            yield return node;
                    }
                }
            }

        }
    }
}
