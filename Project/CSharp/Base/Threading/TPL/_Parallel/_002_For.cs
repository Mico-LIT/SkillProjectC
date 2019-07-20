using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL._Parallel
{
    public class _002_For
    {
        public _002_For()
        {
            int[] data = new int[100000000];

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = i * i * i / 123;
            }

            stopwatch.Stop();
            Console.WriteLine($"Time processing : {stopwatch.ElapsedTicks}");
            stopwatch.Reset();

            Action<int> action = (int i) => data[i] = i * i * i / 123; ;
            stopwatch.Start();
            ParallelLoopResult parallelLoopResult =  Parallel.For(0, data.Length, action);
            stopwatch.Stop();
            Console.WriteLine($"Time processing Parallel.For : {stopwatch.ElapsedTicks}");

        }
    }
}
