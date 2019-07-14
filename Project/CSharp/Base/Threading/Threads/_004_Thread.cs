using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CSharp.Base.Threading.Threads
{
    class _004_Thread
    {
        public _004_Thread()
        {
            Counter count = new Counter(1,1);
            Thread thred = new Thread(count.Method);
            thred.Start();

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine($"{count.MyProperty +count.MyProperty2}");
                Thread.Sleep(300);
            }

        }

        class Counter
        {
            public int MyProperty { get; set; }

            public int MyProperty2 { get; set; }

            public Counter(int t1, int t2)
            {
                this.MyProperty = t1;
                this.MyProperty2 = t2;
            }

          public void Method()
            {
                for (int i = 0; i < 20; i++)
                {
                    Console.WriteLine(new string(' ',20)+$"{MyProperty + MyProperty2}");
                    ++MyProperty;
                    ++MyProperty2;
                    Thread.Sleep(300);
                }
            }
        }
    }
}
