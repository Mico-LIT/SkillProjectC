using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.ClassObject
{
    class MyClass : ICloneable
    {
        public int a, b;
        public MyClass()
        {
            Thread.Sleep(1000);
            a = new Random().Next(1, 10);
            Thread.Sleep(1000);
            b = new Random().Next(1, 10);
        }

        public object Clone()
        {
           return this.MemberwiseClone();
        }

    }
    class Cloning
    {
        public Cloning()
        {
            Stopwatch time = new Stopwatch();

            time.Start();
            MyClass myclass = new MyClass();
            myclass.a = 1; myclass.b = 2;
            time.Stop();
            Console.WriteLine(time.Elapsed.Ticks);
            Console.WriteLine($"{ myclass.a} {myclass.b}");

            time.Reset();

            time.Start();
            MyClass clone = myclass.Clone() as MyClass;
            clone.a = 111; clone.b = 222;

            time.Stop();
            Console.WriteLine(time.Elapsed.Ticks);
            Console.WriteLine($"{ clone.a} {clone.b}");

            Console.ReadLine();
        }
    }
}
