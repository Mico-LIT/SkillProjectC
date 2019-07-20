using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL
{
    public class _017_TPL_ContinuationOptions
    {
        public _017_TPL_ContinuationOptions()
        {
            Task<int> task = new Task<int>(MyTask);
            Action<Task<int>> continuation;

            continuation = t => Console.WriteLine($"Result: {t.Result}");
            task.ContinueWith(continuation, TaskContinuationOptions.OnlyOnRanToCompletion);

            continuation = t => Console.WriteLine($"Inner Exception: {t.Exception}");
            task.ContinueWith(continuation, TaskContinuationOptions.OnlyOnFaulted);

            task.Start();

            Console.ReadLine();
        }

        static int MyTask()
        {
            byte result = 255;

            checked
            {
                result += 1;
            }

            return result;
        }
    }
}
