using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharp.Base.Threads.Synchronization
{
    /// <summary>
    /// Класс Semaphore исп для управления доступом к пулу ресурсов.
    /// </summary>
    class _Semaphore
    {
        static Semaphore pool;

        void Method(object number)
        {
            pool.WaitOne();

            Console.WriteLine("Поток {0} занят слот семафора.",number);
            Thread.Sleep(2000);
            Console.WriteLine("Поток {0} ---> Освободил слот.", number);

            pool.Release();
        }

        public _Semaphore()
        {
            ///Нужно пояснение
            pool = new Semaphore(2,4,"MySemafore");

            for (int i = 1; i <= 8; i++)
            {
                new Thread(Method).Start(i);
            }
        }
    }
}
