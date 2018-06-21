using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Delegats.EventsAndDelegates
{
    class EventsAndDelegates
    {
        public delegate void MyDelegate();

        void Method1()
        {
            Console.WriteLine("Method1");
            Console.ReadLine();
        }

        void Method2()
        {
            MyDelegate myDelegate = new MyDelegate(Method1);
            myDelegate.Invoke();
        }
    }
}
