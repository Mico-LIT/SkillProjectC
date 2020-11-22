using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Algorithms
{
    class InsertionSort
    {
        public InsertionSort()
        {
            //int[] arr = { 5, 4, 3, 2, 1, 77, 3, 11 };
            int[] arr = { 2,4,1,3,7,9,5 };

            sort(ref arr);
            display(arr);

            Console.Read();
        }

        void sort(ref int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i + 1].CompareTo(arr[i]) < 0)
                {
                    int indexInserted = getIndexInserted(arr, arr[i + 1]);
                    insertedMethod(arr, indexInserted, i + 1);
                }
        }

        void insertedMethod(int[] arr, int indexInserted, int sortedIndexEndRange)
        {
            var tmp = arr[indexInserted];

            arr[indexInserted] = arr[sortedIndexEndRange];

            for (int i = sortedIndexEndRange; i > indexInserted; i--)
                arr[i] = arr[i - 1];

            arr[indexInserted + 1] = tmp;
        }

        int getIndexInserted(int[] arr, int v)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i].CompareTo(v) > 0)
                    return i;

            throw new InvalidOperationException("Index not find");
        }

        void display(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine("{0}", arr[i]);

            Console.WriteLine(new string('_', 20));
        }
    }
}
