using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.ClassObject
{

    // Клонирование глубокое. граф
    //class A { public int a = 1; }
    //class B : A { public int b = 2; }
    //class C : B { public int c = 3;  }
    //class X : C { }

    // Клонирование ассоциации происходит поверхностно.
    class A { public int a = 1; }
    class B { public int b = 2; }
    class C { public B B = new B(); }

    class X
    {
        public A A = new A();
        public C C = new C();
    }

    class ClassObj5 : X
    {

        public ClassObj5()
        {
            ClassObj5 prog = new ClassObj5();

            Console.WriteLine($" Original {prog.A.a} {prog.C.B.b}");

            ClassObj5 clone = prog.MemberwiseClone() as ClassObj5;
            Console.WriteLine($" Clone {prog.A.a} {prog.C.B.b}");

            // Проверка на глубокое клонирование (Поверхностное клонирование)
            clone.A.a = clone.C.B.b = 7;

            Console.WriteLine($" Original {prog.A.a} {prog.C.B.b}");
            Console.WriteLine($" Clone {prog.A.a} {prog.C.B.b}");

            Console.ReadLine();
        }
    }
}
