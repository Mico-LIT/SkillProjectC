using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharp.Base.Threads.Thread10
{
    class Thread10
    {
        // Счетчик потоков
        static long counter;
        static object block = new object();

        public void Procedure()
        {
            for (int i = 0; i < 1000000; i++)
            {
                //Interlocked.Increment(ref counter);

                lock (block)
                {
                    counter++;
                }
            }
        }

        public Thread10()
        {
            Console.WriteLine("Ожидаемое значение 1000000");
            Thread thread = new Thread(Procedure);
            thread.Start();
            Thread.Sleep(10);
            Console.WriteLine("Реальное " + counter);
            Console.Read();
        }
    }
}
