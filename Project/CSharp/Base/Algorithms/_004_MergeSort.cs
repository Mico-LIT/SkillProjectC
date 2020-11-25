using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Algorithms
{
    public class _004_MergeSort
    {
        // TODO 00:59:00 - Урок 6. Алгоритмы сортировки
        public _004_MergeSort()
        {
            int[] arr = { 3, 8, 2, 1, 5, 4, 6, 7 };

            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);
            Console.WriteLine("___________________________");

            mergeSort(arr);

            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);

            Console.ReadLine();
        }

        private void mergeSort(int[] arr)
        {
            // если массив содержит 
            if (arr.Length <= 1)
                return;
            //

            int leftSize = arr.Length / 2;
            int rightSize = arr.Length - leftSize;

            int[] left = new int[leftSize];
            int[] right = new int[rightSize];

            Array.Copy(arr, 0, left, 0, leftSize);
            Array.Copy(arr, leftSize, right, 0, rightSize);

            mergeSort(left);
            mergeSort(right);

            merge(arr, left, right);
        }

        private void merge(int[] arr, int[] left, int[] right)
        {
            int leftIndex = 0;
            int rightIndex = 0;
            int targetIndex = 0;
            int remaining = left.Length + right.Length;

            while (remaining > 0)
            {
                if (leftIndex >= left.Length)
                {
                    arr[targetIndex] = right[rightIndex++];
                }
                else if (rightIndex >= right.Length)
                {
                    arr[targetIndex] = left[leftIndex++];
                }
                else if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
                {
                    arr[targetIndex] = left[leftIndex++];
                }
                else
                {
                    arr[targetIndex] = right[rightIndex++];
                }

                remaining--;
                targetIndex++;
            }
        }
    }
}
