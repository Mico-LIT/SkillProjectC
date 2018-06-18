using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Итоги: 
/// 1 ) В C # мы можем приравнивать объект базового класса к производному классу, но не наоборот.
/// 2 )Модификатор переопределения необходим, поскольку методы производного класса получат первый приоритет и будут вызваны.
/// 3 )Эти модификаторы, такие как new и override, могут использоваться только в том случае, 
///     если метод в базовом классе является виртуальным методом.
///     Виртуальный означает, что базовый класс предоставляет нам 
///     разрешение на вызов метода из производного класса, а не базового класса.
///     Но нам нужно добавить переопределение модификатора, если нужно вызвать метод производного класса.
/// 4 )Если объект базового класса объявил метод virtual и производный класс использовал переопределение модификатора, 
///     будет вызван метод производного класса.В противном случае будет выполнен метод базового класса. 
///     Поэтому для виртуальных методов тип данных создается только во время выполнения.
/// 5 )Все методы, не отмеченные виртуальными, не являются виртуальными, и метод, 
///     который должен быть вызван, определяется во время компиляции 
///     в зависимости от статического типа данных объекта.
/// 6 )Метод переопределения - это метод с включенным модификатором переопределения. 
///     Это вводит новую реализацию метода.Мы не можем использовать модификаторы, 
///     такие как новые, статические или виртуальные вместе с переопределением. Но аннотация разрешена.
/// </summary>

namespace OOP.Base.Полиморфизм
{
    /// <summary>
    /// Памятка: 
    /// 1) в C # мы можем приравнивать объект базового класса к производному классу, но не наоборот.
    /// 2) модификатор переопределения необходим, поскольку методы производного класса получат первый приоритет и будут вызваны.
    /// 3)
    /// </summary>
    class InheritanceAndPolymorphismV2
    {

        class ClassB
        {
            public virtual void AAA()
            {
                Console.WriteLine("ClassB AAA");
            }
            public virtual void BBB()
            {
                Console.WriteLine("ClassB BBB");
            }
            public virtual void CCC()
            {
                Console.WriteLine("ClassB CCC");
            }
        }

        /// <summary>
        /// Класс ClassB является суперклассом класса ClassA
        /// </summary>
        class ClassA : ClassB
        {
            public override void AAA()
            {
                Console.WriteLine("ClassA AAA");
            }

            /// <summary>
            /// New Предполагает, что он не имеет никакого отношения к базовому классу.
            /// </summary>
            public new void BBB()
            {
                Console.WriteLine("ClassA BBB");
            }
            public void CCC()
            {
                Console.WriteLine("ClassA CCC");
            }
        }

        public InheritanceAndPolymorphismV2()
        {
            ClassB y = new ClassB();
            ClassA x = new ClassA();
            ClassB z = new ClassA();
            y.AAA(); y.BBB(); y.CCC();

            x.AAA(); x.BBB(); x.CCC();

            z.AAA(); z.BBB(); z.CCC();
            Console.ReadKey();
        }
        
    }

    /// <summary>
    /// Следует помнить:
    /// Если объект базового класса объявляет метод virtual,
    /// а производный класс использует переопределение модификатора, будет 
    /// вызываться метод производного класса. В противном случае будет выполнен 
    /// метод базового класса. Поэтому для виртуальных методов тип данных создается только во время выполнения. 
    /// 
    /// Следует помнить:
    /// все методы, не отмеченные виртуальными, 
    /// не являются виртуальными, и метод, который должен быть вызван, 
    /// определяется во время компиляции в зависимости от статического типа данных объекта.
    /// </summary>
    ///
    /// Шаги выполнения:
    /// y.BBB также делает то же самое, но теперь метод теперь определяется виртуальным в классе ClassB. 
    /// Таким образом, C # смотрит на класс ClassB, тот, который был инициализирован. 
    /// Здесь BBB отмечен модификатором «новый». Это означает, 
    /// что BBB - это новый метод, который не имеет ничего общего с базовым классом. 
    /// Они только случайно используют одно и то же имя. 
    /// Поэтому, поскольку в производном классе нет метода BBB (как новый BBB), 
    /// вызывается один из базового класса. В сцене y.CCC () повторяются те же шаги выше, 
    /// но в классе ClassB мы видим переопределение модификатора, которое поведением переопределяет метод в базовом классе. 
    class InheritanceAndPolymorphismV2_1
    {

        class ClassB
        {
            public void AAA()
            {
                Console.WriteLine("ClassB AAA");
            }
            public virtual void BBB()
            {
                Console.WriteLine("ClassB BBB");
            }
            public virtual void CCC()
            {
                Console.WriteLine("ClassB CCC");
            }
        }

        /// <summary>
        /// Класс ClassB является суперклассом класса ClassA
        /// </summary>
        class ClassA : ClassB
        {
            public virtual void AAA()
            {
                Console.WriteLine("ClassA AAA");
            }

            public new void BBB()
            {
                Console.WriteLine("ClassA BBB");
            }
            public override void CCC()
            {
                Console.WriteLine("ClassA CCC");
            }
        }

        class ClassC : ClassA
        {
            public override void AAA()
            {
                Console.WriteLine("ClassC AAA");
            }
            
            public void CCC()
            {
                Console.WriteLine("ClassC CCC");
            }
        }

        public InheritanceAndPolymorphismV2_1()
        {
            ClassB y = new ClassA();
            ClassB x = new ClassC();
            ClassA z = new ClassC();

            y.AAA(); y.BBB(); y.CCC();
            /*ClassB AAA
             ClassB BBB
             ClassA CCC*/

            x.AAA(); x.BBB(); x.CCC();
            /*ClassB AAA
             ClassB BBB
             ClassA CCC*/
            z.AAA(); z.BBB(); z.CCC();
            /*ClassC AAA
            ClassA BBB
            ClassA CCC*/
            Console.ReadKey();
        }

    }

    class InheritanceAndPolymorphismV2_2
    {
        internal class A
        {
            public virtual void X()
            {
                Console.WriteLine("Class: A ; Method X");
            }
        }
        internal class B : A
        {
            public new virtual void X()
            {
                Console.WriteLine("Class: B ; Method X");
            }
        }
        internal class C : B
        {
            public override void X()
            {
                Console.WriteLine("Class: C ; Method X");
            }
        }

        public InheritanceAndPolymorphismV2_2()
        {
            A a = new C();
            a.X();
            // ("Class: A ; Method X");
            B b = new C();
            b.X();
            // ("Class: B ; Method X");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Хороший пример
    /// </summary>
    class InheritanceAndPolymorphismV2_3
    {
        public class ClassA
        {
            public virtual void XXX()
            {
                Console.WriteLine("ClassA XXX");
            }
        }
        public class ClassB : ClassA
        {
            public override void XXX()
            {
                Console.WriteLine("ClassB XXX");
            }
        }
        public class ClassC : ClassB
        {
            public new virtual void XXX()
            {
                Console.WriteLine("ClassC XXX");
            }
        }
        public class ClassD : ClassC
        {
            public override void XXX()
            {
                Console.WriteLine("ClassD XXX");
            }
        }

        public InheritanceAndPolymorphismV2_3()
        {
            ClassA a = new ClassD();
            ClassB b = new ClassD();
            ClassC c = new ClassD();
            ClassD d = new ClassD();
            a.XXX();
            // ClassB XXX
            b.XXX();
            // ClassB XXX
            c.XXX();
            // ClassD XXX
            d.XXX();
            // ClassD XXX
            Console.ReadKey();
        }
    }

    class InheritanceAndPolymorphismV2_4
    {
        public class ClassA
        {
            public virtual void XXX()
            {
                Console.WriteLine("ClassA XXX");
            }
        }
        public class ClassB : ClassA
        {
            public override void XXX()
            {
                base.XXX();
                Console.WriteLine("ClassB XXX");
            }
        }
        public class ClassC : ClassB
        {
            public override void XXX()
            {
                base.XXX();
                Console.WriteLine("ClassC XXX");
            }
        }
        public class ClassD : ClassC
        {
            public override void XXX()
            {
                Console.WriteLine("ClassD XXX");
            }
        }

        public InheritanceAndPolymorphismV2_4()
        {
            ClassA a = new ClassB();
            a.XXX();
            //("ClassA XXX");
            //("ClassB XXX");
            ClassB b = new ClassC();
            b.XXX();
            //("ClassA XXX");
            //("ClassB XXX");
            //("ClassC XXX");
            Console.ReadKey();
        }
    }

    /// <summary>
    /// Error: {Cannot evaluate expression because the current thread is in a stack overflow state.}
    /// </summary>
    class InheritanceAndPolymorphismV2_5
    {
        public class ClassA
        {
            public virtual void XXX()
            {
                Console.WriteLine("ClassA XXX");
            }
        }

        public class ClassB : ClassA
        {
            public override void XXX()
            {
                ((ClassA)this).XXX();
                Console.WriteLine("ClassB XXX");
            }
        }

        public InheritanceAndPolymorphismV2_5()
        {
            ClassA a = new ClassB();
            a.XXX();
        }
    }

}
