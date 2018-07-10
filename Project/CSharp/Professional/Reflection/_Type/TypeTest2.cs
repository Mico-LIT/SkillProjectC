using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.Reflection._Type
{
    interface IInterface1
    {
        void MethodA();
    }
    interface IInterface2
    {
        void MethodB();
    }

    class Myclass : IInterface1, IInterface2
    {
        // Поля
        public int myint;
        private string mystring = "Hello";

        // Конструкторы.
        public Myclass() { }
        public Myclass(int i)
        {
            this.myint = i;
        }

        // Свойства.
        public int myProp
        {
            get { return myint; }
            set { this.myint = value; }
        }

        public string MyString
        {
            get { return mystring; }
        }


        public void MethodA() { }

        public void MethodB() { }

        private void MethodC(string s1, string s2)
        {
            Console.WriteLine(s1 + s2);
        }

        public void myMethod(int p1, string p2) { }
    }

    class TypeTest2 
    {
        public TypeTest2()
        {
            Myclass myclass = new Myclass();


            #region Вывод информиции о типе

            ListVariosStats(myclass); // Получаем разную информацию
            ListMethods(myclass);
            ListFilds(myclass);
            ListProps(myclass);
            ListInterfaces(myclass);
            ListConstructor(myclass);

            #endregion

            Console.WriteLine(new string('_', 20));

            Type t = myclass.GetType();

            // Вызов Private метода
            MethodInfo met = t.GetMethod("MethodC", BindingFlags.Instance | BindingFlags.NonPublic);
            met.Invoke(myclass, new object[] { "Hello", " world!" });

            // Запись значения в private поле
            FieldInfo mystr = t.GetField("mystring", BindingFlags.Instance | BindingFlags.NonPublic);
            mystr.SetValue(myclass,"Привет мир");

            Console.WriteLine($"{myclass.MyString}");

            Console.ReadLine();
        }

        private void ListConstructor(Myclass myclass)
        {
            Console.WriteLine(new string('_', 20));

            Type t = myclass.GetType();

            ConstructorInfo[] con = t.GetConstructors();

            foreach (var item in con)
            {
                Console.WriteLine(item.Name);
            }

        }

        private void ListInterfaces(Myclass myclass)
        {
            Console.WriteLine(new string('_', 20));

            Type t = myclass.GetType();
            Type[] it = t.GetInterfaces();

            foreach (Type item in it)
            {
                Console.WriteLine($"Interface {item.Name}");
            }
        }

        private void ListProps(Myclass myclass)
        {
            Console.WriteLine(new string('_', 20));

            Type t = myclass.GetType();

            PropertyInfo[] prop = t.GetProperties();

            foreach (var item in prop)
            {
                Console.WriteLine($"Prop : {item.Name} {item.PropertyType}");
            }
        }

        private void ListFilds(Myclass myclass)
        {
            Console.WriteLine(new string('_', 20));

            Type t = myclass.GetType();
            FieldInfo[] filds = t.GetFields(
                BindingFlags.Instance|
                BindingFlags.Static|
                BindingFlags.Public|
                BindingFlags.NonPublic);

            foreach (var item in filds)
            {
                Console.WriteLine($" Fild: {item.Name}");
            }
        }

        private void ListMethods(Myclass myclass)
        {
            Console.WriteLine(new string('_', 20));

            Type t = myclass.GetType();
            MethodInfo[] mi = t.GetMethods(
                BindingFlags.Instance | 
                BindingFlags.Static | 
                BindingFlags.Public | 
                BindingFlags.NonPublic | 
                BindingFlags.DeclaredOnly);

            foreach (var item in mi)
            {
                Console.WriteLine($"Method: {item.Name}");
            }


        }

        private void ListVariosStats(Myclass myclass)
        {
            Console.WriteLine(new string('_',20));

            Type t = myclass.GetType();

            Console.WriteLine($"Полное имя {t.FullName}");
            Console.WriteLine($"Базовый класс {t.BaseType}");
            Console.WriteLine($"Абстрактный {t.IsAbstract}");
            Console.WriteLine($"Это COM объект{t.IsCOMObject}");
            Console.WriteLine($"Запрещено наследование {t.IsSealed}");
            Console.WriteLine($"этот класс {t.IsClass}");
        }
    }
}
