using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threads.Thread9
{
    class Thread9
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

        public Thread9()
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
