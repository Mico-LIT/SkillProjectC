using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Algorithms
{
    public class _003_SelectedSort
    {
        public _003_SelectedSort()
        {
            int[] arr = { 2, 4, 1, 3, 7, 9, 5 };

            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);
            Console.WriteLine("___________________________");
            sort(arr);

            for (int i = 0; i < arr.Length; i++)
                Console.WriteLine(arr[i]);

            Console.ReadLine();
        }

        private void sort(int[] arr)
        {
            int sorterdArrIndexEnd = 0;

            while (sorterdArrIndexEnd < arr.Length)
            {
                int index = getIndexElementForReplace(arr, sorterdArrIndexEnd);
                swap(arr, sorterdArrIndexEnd, index);

                sorterdArrIndexEnd++;
            }
        }

        private void swap(int[] arr, int leftIndex, int rigthIndex)
        {
            if (leftIndex != rigthIndex)
            {
                var tmp = arr[leftIndex];
                arr[leftIndex] = arr[rigthIndex];
                arr[rigthIndex] = tmp;
            }
        }

        private int getIndexElementForReplace(int[] arr, int sorterdArrIndexEnd)
        {
            int smallestElementValue = arr[sorterdArrIndexEnd];
            int smallestElementIndex = sorterdArrIndexEnd;

            for (int i = sorterdArrIndexEnd + 1; i < arr.Length; i++)
                if (arr[i].CompareTo(smallestElementValue) < 0)
                {
                    smallestElementValue = arr[i];
                    smallestElementIndex = i;
                }

            return smallestElementIndex;
        }
    }
}
