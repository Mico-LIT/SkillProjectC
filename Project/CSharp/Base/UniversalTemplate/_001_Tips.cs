using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate
{
    class _001_Tips
    {
        public _001_Tips()
        {
            var list = new List<Item>();
            list.Add(new Item<int>());
            list.Add(new Item<double>());
        }

        public class Item<T> : Item 
        { }

        public class Item 
        { }
    }
}
