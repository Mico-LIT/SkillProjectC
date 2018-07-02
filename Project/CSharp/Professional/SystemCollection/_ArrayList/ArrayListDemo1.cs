using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.SystemCollection._ArrayList
{
    class ArrayListDemo1
    {
        public ArrayListDemo1()
        {
            var list = new ArrayList { 2, 3, 1 };

            list.Sort(new SortComparer());

            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        class SortComparer : IComparer
        {
            readonly CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();

            public int Compare(object x, object y)
            {
                int result = comparer.Compare(x, y);

                //int result = (int)y - (int)x; // Убыванию
                //int result = (int)x - (int)y;   // возрастанию

                return result;
            }
        }
    }
}
