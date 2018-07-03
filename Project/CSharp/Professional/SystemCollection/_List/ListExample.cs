using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.SystemCollection._List
{
    class ListExample
    {
        class MyReverseComparer<T> : Comparer<T>
        {
            public override int Compare(T x, T y)
            {
                return y.GetHashCode() - x.GetHashCode();
            }
        }

        public ListExample()
        {
            var intList = new List<int>() { 1, 2, 3 };
            var reverseComparer = new MyReverseComparer<int>();

            int number = intList[0];
            Console.WriteLine("Original List");
            PrintList(intList);

            Console.WriteLine("a. Sort(Comparision<T> comparison)");

            intList.Sort(new Comparison<int>((x, y) => x - y));
            PrintList(intList);

            Console.WriteLine("b. Sort(IComparer<T> comparer)");
            intList.Sort(reverseComparer);
            PrintList(intList);

            Console.ReadLine();
        }

        void PrintList<T>(IEnumerable<T> intList)
        {
            foreach (T item in intList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('_',5));
        }
    }
}
