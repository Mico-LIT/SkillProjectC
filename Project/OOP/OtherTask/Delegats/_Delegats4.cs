using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Delegats4
{
    delegate void MyDelegats();

    class _Delegats4
    {
        public _Delegats4()
        {
            MyDelegats myDelegats = delegate { Console.WriteLine("12"); };

            myDelegats.Invoke();
        }
    }
}
