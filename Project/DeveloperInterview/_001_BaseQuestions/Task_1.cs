using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseQuestions
{
    class Task_1
    {
       public class A
        {
            /// <summary>
            /// Виртуальные и абстрактные члены не могут быть private
            /// </summary>
            public virtual void Foo()
            {
                Console.Write("Class A");
            }
            
        }
        public class B : A
        {
            /// <summary>
            /// Виртуальные и абстрактные члены не могут быть private
            /// </summary>
            public override void Foo()
            {
                Console.Write("Class B");
            }
        }

        /// <summary>
        /// Что выведут на консоль такие вызовы метода Foo():
        /// </summary>
        public void Process()
        {
            // B obj1 = new A(); //Oшибка

            B obj2 = new B();
            obj2.Foo();

            A obj3 = new B();
            obj3.Foo();
        }
    }
}
