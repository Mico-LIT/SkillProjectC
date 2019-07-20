using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL._Parallel
{
    public class _001_Invoke
    {
        public _001_Invoke()
        {
            Console.WriteLine("Run");

            ParallelOptions parallelOptions = new ParallelOptions();

            parallelOptions.MaxDegreeOfParallelism = 1;

            Console.WriteLine($"Core CPU : {Environment.ProcessorCount}");
            Console.ReadLine();

            Parallel.Invoke(parallelOptions, MyTask, MyTask2);
            //Parallel.Invoke(parallelOptions, MyTask, MyTask2,MyTask,MyTask2);

            Console.Read();
        }

        static void MyTask()
        {
            Console.WriteLine("MyTask running");
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(100);
                Console.Write("-");
            }
            Console.WriteLine("MyTask completed");
        }

        static void MyTask2()
        {
            Console.WriteLine("MyTask2 running");
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(100);
                Console.Write("+");
            }
            Console.WriteLine("MyTask2 completed");
        }
    }
}
