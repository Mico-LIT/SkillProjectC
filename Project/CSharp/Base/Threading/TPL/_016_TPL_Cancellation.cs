using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL
{
    public class _016_TPL_Cancellation
    {
        public _016_TPL_Cancellation()
        {
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            CancellationToken cancellationToken = cancellationTokenSource.Token;

            Task task = new Task(MyTask, cancellationToken);
            task.Start();

            Thread.Sleep(2000);

            try
            {
                cancellationTokenSource.Cancel(); // отмена задачи
                task.Wait(); // для обработки исключения обязательно вызвать Wait
            }
            catch (Exception ex)
            {
                if (task.IsCanceled)
                    Console.WriteLine("Task canceled");

                Console.WriteLine($"Inner Exception: {ex.InnerException.GetType()}");
                Console.WriteLine($"Message        : {ex.InnerException.Message}");
                Console.WriteLine($"Status Task     : {task.Status}");

                throw;
            }
        }

        static void MyTask(object arg)
        {
            CancellationToken token = (CancellationToken)arg;

            // Если задача сразу после старта отменена- возбудить OperationCanceledException
            token.ThrowIfCancellationRequested();

            Console.WriteLine("Task Running");

            for (int i = 0; i < 80; i++)
            {
                if (token.IsCancellationRequested)
                {
                    Console.WriteLine("\nПолучен запрос на отмену задачи");
                    //token.ThrowIfCancellationRequested();
                    throw new OperationCanceledException("Error in task");
                }

                Thread.Sleep(100);
                Console.Write(".");
            }

            Console.WriteLine("Task Completed");
        }
    }
}
