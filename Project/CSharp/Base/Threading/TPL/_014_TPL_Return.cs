using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL
{
    public class _014_TPL_Return
    {
        struct Context
        {
            public int a;
            public int b;
        }

        public _014_TPL_Return()
        {
            Context context;
            context.a = 2;
            context.b = 3;

            Task<int> task;

            // Option 1
            //task = new Task<int>(Sum, context);
            //task.Start();

            // Option 2 
            //TaskFactory<int> factory = new TaskFactory<int>();
            //task = factory.StartNew(Sum, context);

            // Oprion 3
            task = Task<int>.Factory.StartNew(Sum, context);

            Console.WriteLine($"Результат выполнения задачи Sum: {task.Result}");
        }

        static int Sum(object arg)
        {
            int a = ((Context)arg).a;
            int b = ((Context)arg).b;

            Thread.Sleep(2000);

            return a + b;
        }
    }
}
