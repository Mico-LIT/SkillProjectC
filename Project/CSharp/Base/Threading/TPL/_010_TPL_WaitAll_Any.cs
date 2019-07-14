using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// WaitAll() - Ожидает завершение всех задач
/// WaitAny() - Ожидает завершения любого из объектов
/// </summary>
namespace CSharp.Base.Threading.TPL
{
    public class _010_TPL_WaitAll_Any
    {
        public _010_TPL_WaitAll_Any()
        {
            Task task1 = new Task(MyTask1);
            Task task2 = new Task(MyTask2);

            task1.Start();
            task2.Start();

            Console.WriteLine($"Task1Id: {task1.Id}");
            Console.WriteLine($"Task2Id: {task2.Id}");

            //Task.WaitAll(task1, task2);
            Task.WaitAny(task1, task2);

            Console.WriteLine("Main thread is completed");

        }

        static void MyTask1()
        {
            Console.WriteLine($"MyTask1: CurrentId {Task.CurrentId} is running");
            Thread.Sleep(2000);
            Console.WriteLine($"MyTask1: CurrentId {Task.CurrentId} is completed");
        }

        static void MyTask2()
        {
            Console.WriteLine($"MyTask2: CurrentId {Task.CurrentId} is running");
            Thread.Sleep(2000);
            Console.WriteLine($"MyTask2: CurrentId {Task.CurrentId} is completed");
        }
    }
}
