using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Algorithms
{
    class BubbleSort
    {
        public BubbleSort()
        {
            int[] arr = { 5, 4, 3, 2, 1, 77, 3, 11 };
            Display(arr);

            Sort(arr);

            Display(arr);

            Display(arr, true);

            Console.ReadLine();
        }

        // Сложность = O(n^2)
        void Sort(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        var buf = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = buf;
                    }
                }
            }
        }

        void Display(int[] arr, bool isRevers = false)
        {
            if (!isRevers)
                foreach (var item in arr)
                    Console.WriteLine(item);
            else
                for (int i = arr.Length - 1; i >= 0; i--)
                    Console.WriteLine(arr[i]);

            Console.WriteLine(new string('_', 30));
        }
    }
}
