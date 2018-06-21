using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.OOP.OverrideMethods
{
    /// <summary>
    /// Понимание переопределения метода и виртуального, переопределения и новых ключевых слов
    /// </summary>
    public class OverrideMethod
    {
        public class Base
        {
            public Base() { }
            public void Function1()
            {
                Console.WriteLine("Base-Fun 1");
            }
            virtual public void Function2()
            {
                Console.WriteLine("Base-Fun 2");
            }
        }

        public class Derived : Base
        {
            public Derived() { }

            public void Function1()
            {
                Console.WriteLine("Derived-Fun 1");
            }
            public override void Function2()
            {
                Console.WriteLine("Derived-Fun 2");
            }
        }

        public OverrideMethod()
        {
            Base b = new Base();
            b.Function2();
            Derived d = new Derived();
            d.Function2();
             //Base bd1 = new Derived();
             //bd1.Function1(); // Не работает в соответствии с принципом переопределения
            Base bd = new Derived();
            bd.Function2(); // Это работает
        }

    }
}
