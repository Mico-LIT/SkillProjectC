using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharp.Base.Threading.Threads
{
    class _003_Thread
    {
        public _003_Thread()
        {
            Thread thread = new Thread(new ParameterizedThreadStart(method));
            thread.Start('2');

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("1");
                Thread.Sleep(300);
            }
        }

        void method(object s)
        {
            char ch = (char)s;
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(new string(ch, 20));
                Thread.Sleep(400);
            }
        }
    }
}
