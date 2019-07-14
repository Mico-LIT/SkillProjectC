using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL
{
    public class _011_TPL_Factory
    {
        public _011_TPL_Factory()
        {
            // option 1
            Task task = Task.Factory.StartNew(MyTask);

            // option 2
            //TaskFactory factory = new TaskFactory();
            //Task task = factory.StartNew(MyTask);
        }

        static void MyTask()
        {
            for (int i = 0; i < 80; i++)
            {
                Thread.Sleep(20);
                Console.WriteLine(".");
            }
        }
    }
}
