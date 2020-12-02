using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.HashTable
{
    public class _005_HashTable
    {
        public _005_HashTable()
        {
            HashTable<string, string> hashTable = new HashTable<string, string>(3);

            hashTable.Add("1", "2");
            hashTable.Add("2", "2");
            hashTable.Add("3", "2");
            hashTable.Add("4", "2");
            hashTable.Add("5", "2");
        }

        class HashTable<TKey, TValue>
        {
            const double _fillFactor = 0.75; // 75%
            int _count;
            int _maxItems;

            _003_HashTableArray.HashTableArray<TKey, TValue> _array;

            public HashTable() : this(1000) { }

            public HashTable(int capacity)
            {
                if (capacity < 1)
                    throw new ArgumentException("number less < 1");

                _array = new _003_HashTableArray.HashTableArray<TKey, TValue>(capacity);
                _maxItems = (int)(_fillFactor * capacity) + 1;
            }

            public void Add(TKey key, TValue value)
            {
                if (_count >= _maxItems)
                {
                    var tmp = new _003_HashTableArray.HashTableArray<TKey, TValue>(_array.Count * 2);

                    foreach (var item in _array)
                        tmp.Add(item.Key, item.Value);

                    _array = tmp;
                    _maxItems = (int)(_fillFactor * _array.Count) + 1;
                }
                _array.Add(key, value);
                _count++;
            }
        }
    }
}
