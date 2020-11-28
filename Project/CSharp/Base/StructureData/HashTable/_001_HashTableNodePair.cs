using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.HashTable
{
    public class _001_HashTableNodePair<TKey, TValue>
    {
        public TKey Key { get; private set; }
        public TValue Value { get; set; }

        public _001_HashTableNodePair(TKey key, TValue value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
