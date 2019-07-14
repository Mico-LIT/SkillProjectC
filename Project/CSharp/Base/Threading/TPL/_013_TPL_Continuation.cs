using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL
{
    public class _013_TPL_Continuation
    {
        public _013_TPL_Continuation()
        {
            Action action = new Action(MyTask);
            Task task = new Task(action);

            Action<Task> continuation = new Action<Task>(ContinuationTask);
            Task task2 = task.ContinueWith(continuation);

            task.Start();

            Console.ReadLine();
        }

        static void MyTask()
        {
            for (int i = 0; i < 20; i++)
            {
                Thread.Sleep(200);
                Console.Write("+");
            }
        }

        static void ContinuationTask(Task task)
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write("-");
            }
        }
    }
}
