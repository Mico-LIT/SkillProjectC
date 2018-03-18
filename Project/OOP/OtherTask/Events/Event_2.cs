using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Events2
{
    delegate void EventsDelegats();
    class MyClass
    {
        EventsDelegats myEvent = null;

        public event EventsDelegats MyEvents
        {
            add { myEvent += value; }
            remove { myEvent -= value; }
        }

        public void InvokeEvent()
        {
            myEvent.Invoke();
        }
    }

    class Event_2
    {
        void Method1()
        {
            Console.WriteLine("1");
        }

        void Method2()
        {
            Console.WriteLine("2");
        }

        public Event_2()
        {
            MyClass myClass = new MyClass();

            myClass.MyEvents += new EventsDelegats(Method1);
            myClass.MyEvents += Method2;
            myClass.InvokeEvent();

        }
    }
}
