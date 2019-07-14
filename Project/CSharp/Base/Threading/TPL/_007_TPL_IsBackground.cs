using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// С завершение метода Main завершиться недовыполненная задача MyTask
/// [завершается работа вторичного потока]
/// По умолчанию IsBackground == true (by Tasks)
/// </summary>
namespace CSharp.Base.Threading.TPL
{
    public class _007_TPL_IsBackground
    {
        public _007_TPL_IsBackground()
        {
            Task task = new Task(MyTask);
            task.Start();

            Thread.Sleep(500);
            Console.WriteLine("END :_007_TPL_IsBackground");
        }

        void MyTask()
        {
            //Thread.CurrentThread.IsBackground = false;

            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(100);
                Console.Write(".");
            }
        }
    }
}
