using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Delegats8
{
    delegate MyDelegat Function(MyDelegat m1, MyDelegat m2);
    delegate string MyDelegat();

    class _Delegats8
    {
        MyDelegat delegat1 = () => "Hi", delegat2 = () => "Mico";

        public _Delegats8()
        {
            Function Fun = delegate (MyDelegat d1, MyDelegat d2)
            {
                return delegate() { return d1.Invoke() + d2.Invoke(); };
            };

            Function Fun1 = delegate (MyDelegat d1, MyDelegat d2)
            {
                return delegate() { return d1() + d2(); };
            };

            Function Fun2 = (MyDelegat d1, MyDelegat d2) => ()=> d1() + d2();
            
        }
    }
}
