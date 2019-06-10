using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threads.TPL
{
    public class _003_TPL
    {
        public _003_TPL()
        {
            Console.WriteLine($"{this.GetType().Name} запущен в потоке: {Thread.CurrentThread.ManagedThreadId}");

            // SlowOperation() первичный поток зайдет в метод и будет выполняться
            // до ключ слова await и вернется сюда
            Task<int> task = SlowOperation();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(i);
            }

            // ожидание результата task.Result
            Console.WriteLine($"результат выполнения медленной операции {task.Result}");
            Console.WriteLine($"{this.GetType().Name} Завершил работу в потоке {Thread.CurrentThread.ManagedThreadId}");


        }

        private async Task<int> SlowOperation()
        {
            Console.WriteLine($" медл операция запущена в потоке {Thread.CurrentThread.ManagedThreadId}");

            await Task.Delay(2000);

            Console.WriteLine($" медл операция запущена в потоке {Thread.CurrentThread.ManagedThreadId} завершина ");

            return 123;
        }

    }
}
