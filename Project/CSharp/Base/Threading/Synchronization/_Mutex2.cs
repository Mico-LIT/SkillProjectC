using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharp.Base.Threading.Synchronization
{
    /// <summary>
    /// Рекурсивное запирание
    /// </summary>
    class _Mutex2
    {
        static Mutex mutex = new Mutex();

        public _Mutex2()
        {
            Thread thread = new Thread(Method);
            thread.Start();
            Console.Read();
        }

        void Method2()
        {
            mutex.WaitOne();
            Console.WriteLine("Method2 start");
            Thread.Sleep(1000);
            mutex.ReleaseMutex();
            Console.WriteLine("Method2 end");
        }
        void Method()
        {
            mutex.WaitOne();
            Console.WriteLine("Method start");
            Method2();
            mutex.ReleaseMutex();
            Console.WriteLine("Method end");
        }
    }
}
