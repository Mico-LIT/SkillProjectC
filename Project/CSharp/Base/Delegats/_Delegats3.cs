using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Delegats.Delegats3
{
   public class _Delegats3
    {
        void Method()
        {
            Console.WriteLine("Method0");
        }
        void Method1()
        {
            Console.WriteLine("Method1");
        }
        void Method2()
        {
            Console.WriteLine("Method2");
        }

        public delegate void MyDelegats();

        public _Delegats3()
        {
            MyDelegats _mydelegate = null;
            MyDelegats mydelegate = new MyDelegats(Method);
            MyDelegats mydelegate1 = new MyDelegats(Method1);
            MyDelegats mydelegate2 = new MyDelegats(Method2);

            _mydelegate = mydelegate + mydelegate1 + mydelegate2;
            Console.WriteLine("Укажите от 1-4");

            int i = int.Parse(Console.ReadLine());

            switch (i)
            {
                case 1:
                    mydelegate();
                    break;
                case 2:
                    mydelegate1();
                    break;
                case 3:
                    mydelegate2.Invoke();
                    break;
                case 4:
                    MyDelegats myDelegats = _mydelegate - mydelegate1;
                    myDelegats.Invoke();
                    break;

                default:
                    break;
            }
        }
    }
}
