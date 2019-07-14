using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL
{
    public class _006_TPL_Status
    {
        public _006_TPL_Status()
        {
            Task task = new Task(MyTask);
            Console.WriteLine($"1. {task.Status}");

            task.Start();
            Console.WriteLine($"2. {task.Status}");

            Thread.Sleep(1000);
            Console.WriteLine($"3. {task.Status}");

            Thread.Sleep(3000);
            Console.WriteLine($"4. {task.Status}");

        }

        static void MyTask()
        {
            Thread.Sleep(3000);
        }
    }
}
