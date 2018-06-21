using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Events
{
    class _Events
    {
        delegate void MyDelegate();

        class EventExercises
        {
            public event MyDelegate mydelegate;

           public void Method1()
            {
                Console.WriteLine("HI");
            }

            public void Method2()
            {
                mydelegate?.Invoke();
            }
        }

        class EventExercisesv1
        {
            public event MyDelegate myevent;
            public void Method1()
            {
                Console.WriteLine("123");
            }
            public void run()
            {
                myevent();
            }
        }

        public _Events()
        {
            EventExercises ee = new EventExercises();
            ee.mydelegate += new MyDelegate(ee.Method1);
            ee.Method2();
            Console.ReadLine();
            /////////////////////
            EventExercisesv1 ee1 = new EventExercisesv1();
            ee1.myevent += new MyDelegate(ee1.Method1);
            ee1.run();
            Console.ReadLine();
        }
    }
}
