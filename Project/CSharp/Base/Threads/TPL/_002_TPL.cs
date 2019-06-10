using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threads.TPL
{
    public class _002_TPL
    {
        public _002_TPL()
        {
            Console.WriteLine($"{this.GetType().Name} запущен в потоке: {Thread.CurrentThread.ManagedThreadId}");

            // SlowOperation() Запускается в отдельном потоке
            Task<int> task = Task.Factory.StartNew<int>(SlowOperation);

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            // ожидание результата task.Result
            Console.WriteLine($"результат выполнения медленной операции {task.Result}");
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
