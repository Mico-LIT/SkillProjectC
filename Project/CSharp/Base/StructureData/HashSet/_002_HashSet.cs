using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.HashSet
{
    class _002_HashSet
    {
        public _002_HashSet()
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 1, 3, 4, 7, 9 };

            // Объединение множеств
            Union(new HashSet<int>(array1), new HashSet<int>(array2));

            // Разность множеств
            Except(new HashSet<int>(array1), new HashSet<int>(array2));

            // Пересечение множеств
            Intersect(new HashSet<int>(array1), new HashSet<int>(array2));

            // Симметрическая разность множеств
            SymmetricExcept(new HashSet<int>(array1), new HashSet<int>(array2));

            // Подмножество
            IsSubset(new HashSet<int>(array1), new HashSet<int>(new int[] { 1, 2, 3, 4, 5, 6, 7 }));
            //

            int[] mass = new int[10];
            var inst = new HashSet<int>(array1);
            inst.CopyTo(mass);

            for (int i = 0; i < mass.Length; i++)
            {
                Console.WriteLine(mass[i]);
            }

            inst.Clear();
        }

        private void IsSubset(HashSet<int> hashSet1, HashSet<int> hashSet2)
        {
            show("set2:", hashSet1);
            show("IsSubset set2:", hashSet2);
            show($"= : {hashSet1.IsSubsetOf(hashSet2)}", Enumerable.Empty<int>());
            Console.Write("\n\n");
        }

        private void SymmetricExcept(HashSet<int> hashSet1, HashSet<int> hashSet2)
        {
            show("set2:", hashSet1);
            show("SymmetricExceptWith set2:", hashSet2);
            hashSet1.SymmetricExceptWith(hashSet2);
            show("= :", hashSet1);
            Console.Write("\n\n");
        }

        private void Intersect(HashSet<int> hashSet1, HashSet<int> hashSet2)
        {
            show("set1:", hashSet1);
            show("IntersectWith set2:", hashSet2);

            hashSet1.IntersectWith(hashSet2);
            show("= :", hashSet1);
            Console.Write("\n\n");
        }

        private void Except(HashSet<int> hashSet1, HashSet<int> hashSet2)
        {
            show("set1:", hashSet1);
            show("ExceptWith set2:", hashSet2);

            hashSet1.ExceptWith(hashSet2);
            show("= :", hashSet1);
            Console.Write("\n\n");
        }

        private void Union(HashSet<int> hashSet1, HashSet<int> hashSet2)
        {
            show("set1:", hashSet1);
            show("UnionWith set2:", hashSet2);

            hashSet1.UnionWith(hashSet2);
            show("= :", hashSet1);
            Console.Write("\n\n");
        }

        private void show(string v, IEnumerable<int> hashSet)
        {
            Console.Write(" {0}\"{1}\" ", v, string.Join(",", hashSet));
        }
    }
}
