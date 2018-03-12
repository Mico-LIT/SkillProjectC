using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Delegats7
{
    delegate MyDelegats3 MyDelegats(MyDelegats1 d1, MyDelegats2 d2);
    delegate string MyDelegats1();
    delegate string MyDelegats2();
    delegate string MyDelegats3();

    class _Delegats7
    {
        MyDelegats3 func (MyDelegats1 d1, MyDelegats2 d2)
        {
            return delegate { return d1.Invoke() + d2.Invoke(); };
        }

        string str1() { return "Hello"; }
        string str2() { return "World"; }

        public _Delegats7()
        {
            MyDelegats mydelegats = new MyDelegats(func);
            MyDelegats3 mydelegats3 = mydelegats.Invoke(new MyDelegats1(str1),new MyDelegats2(str2));

            Console.WriteLine(mydelegats3.Invoke());
        }
    }
}
