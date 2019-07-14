using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL
{
    public class _005_TPL_Id
    {
        public _005_TPL_Id()
        {
            Task task1 = new Task(MyTask);
            Task task2 = new Task(MyTask);

            task1.Start();
            task2.Start();

            Console.WriteLine($"Id Задачи task1: {task1.Id}");
            Console.WriteLine($"Id Задачи task2: {task2.Id}");

            Console.ReadLine();
        }

        static void MyTask()
        {
            Console.WriteLine($"MyTask: {Task.CurrentId} ManagerThreadId: {Thread.CurrentThread.ManagedThreadId}");

            Thread.Sleep(2000);

            Console.WriteLine($"MyTask: CurrentId {Task.CurrentId} Завершен");
        }
    }
}
