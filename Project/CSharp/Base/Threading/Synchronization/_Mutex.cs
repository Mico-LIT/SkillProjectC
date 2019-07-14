using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharp.Base.Threading.Synchronization
{

/// <summary>
///  Mutex - Примитив синхронизации, который также может использоваться
///  в межпроцессной и междомменной синхронизации
/// </summary>
    class _Mutex
    {
        //static Mutex mutex = new Mutex();
        static Mutex mutex = new Mutex(false,"MyMutex");

        public _Mutex()
        {
            Thread[] thread = new Thread[5];

            for (int i = 0; i < 5; i++)
            {
                thread[i] = new Thread(Method);
                thread[i].Name = i.ToString();
                thread[i].Start();
            }

            Console.Read();
        }

        void Method()
        {
            mutex.WaitOne();
            Console.WriteLine("Поток {0} Зашел",Thread.CurrentThread.Name);
            Thread.Sleep(2000);
            Console.WriteLine("Поток {0} Вышел \n", Thread.CurrentThread.Name);
            mutex.ReleaseMutex();
        }
    }
}
