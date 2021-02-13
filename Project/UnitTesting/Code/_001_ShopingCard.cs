using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    [Serializable]
    public class _001_ShopingCard : IDisposable
    {
        public List<Item> Items = new List<Item>();

        public int Count => Items.Count;

        public void Add(Item item)
        {
            Items.Add(item);
        }

        public void Dispose()
        {
        }

        public void Removed(int index)
        {
            Items.RemoveAt(index);
        }

        [Serializable]
        public class Item
        {
            public string Name { get; set; }
            public int Quantity { get; set; }

        }
    }

}
