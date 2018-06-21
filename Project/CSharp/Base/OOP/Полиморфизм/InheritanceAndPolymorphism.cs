using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.OOP.Полиморфизм
{
    class InheritanceAndPolymorphism
    {
        /// <summary>
        /// КлассA теперь считается производным от ClassB
        /// </summary>
        class A :B
        {
            public void Display1()
            {
                Console.WriteLine("Class A Display1");
            }
        }

        class B
        {
            public int x = 100;
            public void Display1()
            {
                Console.WriteLine("Class B Display1");
            }
            public void Display2()
            {
                Console.WriteLine("Class B Display2");
            }
        }

        public InheritanceAndPolymorphism()
        {
            A a = new A();
            a.Display1();
            Console.ReadLine();
        }
    }
}
