using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.HashTable
{
    public class _003_HashTableArray
    {
        public _003_HashTableArray()
        {
            HashTableArray<string, string> hashTableArray = new HashTableArray<string, string>(10);
            hashTableArray.Add("1", "2");
            hashTableArray.Add("2", "3432");
            hashTableArray.Add("3", "55555");
            hashTableArray.Add("4", "8888");

            hashTableArray.Update("4", "tttt");

            foreach (var item in hashTableArray)
            {
                Console.WriteLine(item.Key);
            }
        }

        public class HashTableArray<TKey, TValue>
        {
            _002_HashTableArrayNode.HashTableArrayNode<TKey, TValue>[] _array;

            public int Count => _array.Length;

            public HashTableArray(int capacity)
            {
                _array = new _002_HashTableArrayNode.HashTableArrayNode<TKey, TValue>[capacity];
            }

            int getIndex(TKey key) { return Math.Abs(key.GetHashCode() % Count); }

            public void Add(TKey key, TValue value)
            {
                int index = getIndex(key);

                _002_HashTableArrayNode.HashTableArrayNode<TKey, TValue> node = _array[index];

                if (node == null)
                {
                    node = new _002_HashTableArrayNode.HashTableArrayNode<TKey, TValue>();
                    _array[index] = node;
                }

                node.Add(key, value);
            }

            public void Update(TKey key, TValue value)
            {
                _002_HashTableArrayNode.HashTableArrayNode<TKey, TValue> node = _array[getIndex(key)];

                if (node == null)
                    throw new ArgumentException("Key not exist");

                node.Update(key, value);
            }

            public bool TryGetValue(TKey key, out TValue value)
            {
                var node = _array[getIndex(key)];

                if (node != null)
                    return node.TryGetValue(key, out value);

                value = default;
                return false;
            }

            public bool Remove(TKey key)
            {
                var node = _array[getIndex(key)];

                if (node != null)
                    return node.Remove(key);

                return false;
            }

            public System.Collections.Generic.IEnumerator<_001_HashTableNodePair<TKey, TValue>> GetEnumerator()
            {
                foreach (_002_HashTableArrayNode.HashTableArrayNode<TKey, TValue> node in _array.Where(x => x != null))
                    foreach (_001_HashTableNodePair<TKey, TValue> pair in node.Items)
                        yield return pair;
            }

        }
    }
}
