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
    class EventsAndDelegatesv1
    {
        public delegate int MyDelegate(int x);

        int Method1(int i)
        {
            return i * i;
        }

        int Method2 (int i)
        {
            return i * 10;
        }

        public EventsAndDelegatesv1()
        {
            MyDelegate myDelegate = new MyDelegate(Method1);
            myDelegate.Invoke(2);
            myDelegate = new MyDelegate(Method2);
            myDelegate(20);
        }
    }
    class EventsAndDelegatesv2
    {
        public delegate int MyDelegate(int x);

        int Method1(int i)
        {
            return i * i;
        }

        int Method2(int i)
        {
            return i * 10;
        }
        
        void Method4(MyDelegate del)
        {
            int rez = del(10);
            Console.WriteLine(rez);
        }

        public EventsAndDelegatesv2()
        {
            MyDelegate myDelegate = new MyDelegate(Method1);
            Method4(myDelegate);
            myDelegate = new MyDelegate(Method2);
            Method4(myDelegate);
        }
    }

    class EventsAndDelegatesv3
    {
        delegate void Mydelegate(string i);

        public static void Method1(string str)
        {
            Console.WriteLine("Method1 " + str);
        }
        public static void Method2(string str)
        {
            Console.WriteLine(new string(' ',20)+ "Method2 " + str);
        }

        public EventsAndDelegatesv3()
        {
            Mydelegate mydelegate, mydelegate2, mydelegate3, mydelegate4;

            mydelegate = new Mydelegate(Method1);
            mydelegate2 = new Mydelegate(Method2);

            mydelegate3 = mydelegate + mydelegate2;
            mydelegate4 = mydelegate - mydelegate2;

            mydelegate.Invoke("AAA");
            mydelegate2("BBB");
            mydelegate3("CCC");

            mydelegate4("DDD");

            mydelegate4 = mydelegate3 - mydelegate;
            mydelegate4("EEE");

            mydelegate4 = mydelegate3 - mydelegate2;
            mydelegate4("FFF");

            Console.ReadLine();
        }
    }

    /// <summary>
    ///  Исключение, вызванное делегатом, продолжает распространяться до тех пор, пока оно не будет поймано. 
    /// </summary>
    class EventsAndDelegatesv4
    {
        delegate void Mydelegate();

        void Method1()
        {
            throw new Exception("ERROR");
        }

        public EventsAndDelegatesv4()
        {
            Mydelegate mydeledate = new Mydelegate(Method1);
            mydeledate();
        }
    }

    class EventsAndDelegatesv5
    {
        delegate void MyDelegate(ref int i);

        void Method1(ref int c)
        {
            c += 5;
            Console.WriteLine(c);
        }

        public EventsAndDelegatesv5()
        {
            MyDelegate mydelegate, mydelegate1;
            mydelegate = new MyDelegate(Method1);
            mydelegate1 = mydelegate + mydelegate;
            int i = 5;
            mydelegate1.Invoke(ref i);
            Console.ReadLine();
        }

    }
}
