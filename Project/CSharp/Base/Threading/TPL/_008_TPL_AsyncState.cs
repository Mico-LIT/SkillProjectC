using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL
{
    public class _008_TPL_AsyncState
    {
        public _008_TPL_AsyncState()
        {
            Action<object> myTask = MyTask;
            Task task = new Task(myTask,".");
            task.Start();

            Thread.Sleep(500);

            // для того что бы AsyncState был не NULL 
            // требуется использовать конструктор Task(Action<object> action, object state);
            // второй аргумент попадает в качестве значения своцства AsyncState
            Console.WriteLine($"\n[{task.AsyncState as string}]");

            Console.ReadLine();
        }

        static void MyTask(object arg)
        {
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(25);
                Console.Write(arg as string);
            }
        }
    }
}
