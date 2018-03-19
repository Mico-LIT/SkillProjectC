using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Events4
{
    delegate void EventsDelegat();

    interface IInterface
    {
        event EventsDelegat MyEvent;
    }

    class BaseClass : IInterface
    {
        EventsDelegat myEvent = null;

        public virtual event EventsDelegat MyEvent
        {
            add
            {
                myEvent += value;
            }
            remove
            {
                myEvent -= value;
            }
        }

        public void InvokEvent()
        {
            myEvent.Invoke();
        }
    }

    class DerivedClass : BaseClass
    {
        public override event EventsDelegat MyEvent
        {
            add
            {
                base.MyEvent += value;
                Console.WriteLine("+={0}",value.Method.Name);
            }
            remove
            {
                base.MyEvent -= value;
                Console.WriteLine("-={0}", value.Method.Name);
            }
        }
    }

    class Events_4
    {
        void Method1()
        {
            Console.WriteLine("1");
        }

        void Method2()
        {
            Console.WriteLine("2");
        }

        public Events_4()
        {
            DerivedClass derivedClass = new DerivedClass();
            derivedClass.MyEvent += new EventsDelegat(Method1);
            derivedClass.MyEvent += Method2;
            derivedClass.InvokEvent();
            derivedClass.MyEvent -= Method2;
            derivedClass.InvokEvent();
        }
    }
}
