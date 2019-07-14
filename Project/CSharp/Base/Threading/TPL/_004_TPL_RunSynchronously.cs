using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL
{
    public class _004_TPL_RunSynchronously
    {
        public _004_TPL_RunSynchronously()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine($"_004_TPL: {threadId}");

            Action action = new Action(MyTask);

            Task task = new Task(action);
            //task.Start();

            task.RunSynchronously();

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write(". ");
            }

            Console.WriteLine($"\n_004_TPL: {threadId}");
        }

        static void MyTask()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            Console.WriteLine($"MyTask Thread Start : {threadId}");

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write("+");
            }

            Console.WriteLine($"\nMyTask Thread End : {threadId}");
        }
    }
}
