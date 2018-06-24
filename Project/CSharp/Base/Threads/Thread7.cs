using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threads.Thread7
{
    class Thread7
    {
        object obj = new object();

        void Method()
        {
            for (int i = 0; i < 10; i++)
            {
                lock (obj)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(new string(' ',20) + "Secondaty");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        public Thread7()
        {
            Thread task = new Thread(Method);
            task.Start();

            for (int i = 0; i < 10; i++)
            {
                lock (obj)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Primary");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}
