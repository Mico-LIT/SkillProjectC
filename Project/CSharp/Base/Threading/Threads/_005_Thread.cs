using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharp.Base.Threading.Threads
{
    // Синхронизация потоков
    class _005_Thread
    {
        static int x = 0;

        // Разделяемый ресурс
        static object locker = new object();
        public _005_Thread()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread th = new Thread(Method);
                th.Name = "thread " + i;
                th.Start();
            }

            Console.ReadLine();
        }

        void Method()
        {
            //try
            //{
            //    Monitor.Enter(locker);
            x = 1;
            lock (locker)
            {
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} Value {x} ");
                    x++;
                    Thread.Sleep(300);
                }
            }
        }
        //}
        //finally
        //{
        //    Monitor.Exit(locker);
        //}
    }
}


