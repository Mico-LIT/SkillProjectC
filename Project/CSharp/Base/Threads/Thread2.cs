using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharp.Base.Threads.Thread2
{
    class Thread2
    {
        public Thread2()
        {
            Thread thread = new Thread(new ThreadStart(Count));
            thread.Start();

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Thread 1");
                Thread.Sleep(300);
            }
        }

        void Count()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(new string(' ',10)+"Thread 2");
                Thread.Sleep(400);
            }
        }
    }
}
