using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL
{
    public class _012_TPL_Lambda
    {
        public _012_TPL_Lambda()
        {
            Task task = Task.Factory.StartNew(new Action(() => {
                for (int i = 0; i < 80; i++)
                {
                    Thread.Sleep(20);
                    Console.Write(".");
                }
            }));

            task.Wait();

            task.Dispose();
        }
    }
}
