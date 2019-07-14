using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.Threads
{
    class _009_Thread
    {
        void Procedure()
        {
            for (int i = 0; i < 500; i++)
            {
                Thread.Sleep(10);
                Console.Write('.');
            }
            Console.WriteLine("\n Завершение вторичного потока");
        }

        public _009_Thread()
        {
            var thread = new Thread(Procedure);

            // IsBackground - устанавливает поток как фоновый. не ждет завершения вторичного потока
            // IsBackground по умолчанию = false
            // thread.IsBackground = true;
            thread.Start();
            Thread.Sleep(500);

            Console.WriteLine("\n Завершение главного потока");
            Console.Read();
        }
    }
}
