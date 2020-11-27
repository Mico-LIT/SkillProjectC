using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.HashTable
{
    public class _002_HashTableArrayNode<Tkey, TValue>
    {
        LinkedList<_001_HashTableNodePair<Tkey, TValue>> _items;

        public void Add(Tkey key, TValue value)
        {
            if (_items == null)
            {
                _items = new LinkedList<_001_HashTableNodePair<Tkey, TValue>>();
            }
            else
            {
                foreach (var item in _items)
                {
                    if (item.Key.Equals(key))
                        throw new InvalidOperationException("Key is exist");
                }
            }

            _items.AddLast(new _001_HashTableNodePair<Tkey, TValue>(key, value));
        }

        public System.Collections.Generic.IEnumerator<Tkey> GetEnumerator()
        {
            if (_items != null)
            {
                foreach (_001_HashTableNodePair<Tkey, TValue> node in _items)
                    yield return node.Key;
            }
        }


        public static void Test()
        {
            var instanse = new _002_HashTableArrayNode<string, string>();

            instanse.Add("1", "2");
            instanse.Add("2", "4");
            instanse.Add("3", "3");

            foreach (var item in instanse)
                Console.WriteLine(item);

        }
    }
}
