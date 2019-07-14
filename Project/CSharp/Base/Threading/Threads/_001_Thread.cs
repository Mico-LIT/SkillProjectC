using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharp.Base.Threading.Threads
{
    class _001_Thread
    {
        public _001_Thread()
        {
            //текущий поток
            Thread thread = Thread.CurrentThread;
            Console.WriteLine($"Имя {thread.Name}");
            thread.Name = "d12";
            Console.WriteLine($"Имя {thread.Name}");
            Console.WriteLine($"запущен ли поток? {thread.IsAlive}");
            Console.WriteLine($"Приоритет{thread.Priority}");
            Console.WriteLine($"Статус потока: {thread.ThreadState}");
            Console.WriteLine($"Домен приложения {Thread.GetDomain().FriendlyName}");
            Console.Read();
        }
    }
}
