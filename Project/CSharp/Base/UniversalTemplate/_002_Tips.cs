using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate
{
    class _002_Tips
    {
        public _002_Tips()
        {
            var a = new Item<int>();
            var d = new Item<int>();
            var c = new Item<double>();

            Console.WriteLine(Item<int>.InstanceCount);   // diff InstanceCount
            Console.WriteLine(Item<double>.InstanceCount);// diff InstanceCount
        }

        public class Item<T>
        {
            public static int InstanceCount;

            public Item()
            {
                InstanceCount++;
            }
        }

        // InstanceCount будет одинаковый

        //public class Item<T> : Item
        //{
        //}

        //public class Item
        //{
        //    public static int InstanceCount;

        //    public Item()
        //    {
        //        InstanceCount++;
        //    }
        //}
    }
}
