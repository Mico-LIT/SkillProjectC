using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.Collections
{
    class _007_SortedSet
    {
        public _007_SortedSet()
        {
            // тоже самое что и HashSet только все множество в упорядоченом виде
            SortedSet<int> vs = new SortedSet<int> { 1, 4, 3, 6, 7, 7, 3, 21, 1, 22, };

            foreach (var item in vs)
            {
                Console.WriteLine(item);
            }

        }
    }
}
