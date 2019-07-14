using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL
{
    /// <summary>
    /// В контексте одного потока
    /// </summary>
    public class _001_TPL
    {
        public _001_TPL()
        {
            // синхронный вызов метода SlowOperation()
            int result = SlowOperation();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine($"результат выполнения медленной операции {result}");
            Console.WriteLine($"{this.GetType().Name} Завершил работу в потоке {Thread.CurrentThread.ManagedThreadId}");
        }

        private int SlowOperation()
        {
            Console.WriteLine($" медл операция запущена в потоке {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(2000);

            Console.WriteLine($" медл операция запущена в потоке {Thread.CurrentThread.ManagedThreadId} завершина ");

            return 123;
        }
    }
}
