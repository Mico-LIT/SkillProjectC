using OOP.OtherTask.Delegats8;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Events1
{
    delegate void EventDelegats();

    class MyClass
    {
        public event EventDelegats MyEvent;

        public void InvokeEvent()
        {
            MyEvent.Invoke();
        }
    }

    class Event_1
    {
        void Method1()
        {
            Console.WriteLine("1");
        }

       public void Method2()
        {
            Console.WriteLine("2");
        }
        
        public Event_1()
        {
            MyClass myClass = new MyClass();
            
            myClass.MyEvent += new EventDelegats(Method1);
            myClass.MyEvent += Method2;
            myClass.MyEvent += delegate () { Console.WriteLine("33"); };

            myClass.InvokeEvent();
        }
    }
}
