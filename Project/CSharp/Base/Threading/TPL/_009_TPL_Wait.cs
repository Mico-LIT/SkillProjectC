using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL
{
    public class _009_TPL_Wait
    {
        public _009_TPL_Wait()
        {
            Task task = new Task(MyTask);
            task.Start();

            Thread.Sleep(500);

            Console.WriteLine($"\ntask.IsCompleted {task.IsCompleted}");

            // Wait end by async task

            // option 1
            task.Wait();

            // option 2
            //while (!task.IsCompleted)
            //    Thread.Sleep(100);

            // option 3
            //IAsyncResult asyncResult = task as IAsyncResult;
            //ManualResetEvent manualResetEvent = asyncResult.AsyncWaitHandle as ManualResetEvent;
            //manualResetEvent.WaitOne();


            Console.WriteLine($"\ntask.IsCompleted {task.IsCompleted}");

        }

        static void MyTask()
        {
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(25);
                Console.WriteLine(".");
            }
        }
    }
}
