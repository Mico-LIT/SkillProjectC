using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL._PLINQ
{
    public class _001_PLINQ
    {
        public _001_PLINQ()
        {
            int[] array = new int[10000000];

            Parallel.For(0, array.Length, (i) => array[i] = i);

            array[1000] = -1;
            array[13000] = -2;
            array[14000] = -3;
            array[1556000] = -4;
            array[9950743] = -5;

            ParallelQuery<int> result = from int x in array.AsParallel<int>()
                         where x < 0
                         select x;

            foreach (var item in result)
            {
                Console.Write(item + " ");
            }

        }
    }
}
