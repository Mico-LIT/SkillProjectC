using System.Runtime.CompilerServices;
using System.Net.NetworkInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.InterviewDeveloper
{
    class Task_7
    {
        class A{
            public virtual void print1()
            {
                Console.WriteLine("A");
            }
            public void Print2()
            {
                Console.WriteLine("A");
            }
        }

        class B:A
        {
            public override void print1()
            {
                Console.WriteLine("B");
            }
        }
        class C : B {
           new public void Print2()
            {
                Console.WriteLine("c");
            }
        }
         
        public void go()
        {
            var c = new C();
            A a = c;

            a.Print2();
            a.print1();
            c.Print2();
            Console.ReadLine();

        }
    }
}
