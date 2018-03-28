using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OOP.OtherTask.Thread4
{
    class Thread4
    {
        public Thread4()
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
