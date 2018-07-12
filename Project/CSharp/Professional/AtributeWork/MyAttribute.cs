using System;
using System.Reflection;

/// <summary>
/// Атрибуты (Аспектно-Ориентированное Программирование)
/// Атрибуты могут использоваться перед объявлениями типов,
/// членов класса, членов интерфейса и перечислений.
/// Виды атрибутов: Предопределенные и Пользовательские.
/// [.......] - секция атрибута
/// объявдение атрибута состоит из Имени атрибута и набора Параметров
/// для атрибутов определяют два вида параметров после Позиционные и Именованные
/// Именнованные параметры всегда распологаются после Позиционных
/// </summary>


namespace CSharp.Professional.AtributeWork
{
    /// <summary>
    /// Для создания втрибута необходимо создать класс производный от класса System.Attribute
    /// Атрибут - [AttributeUsage] - задает свойство пользовательских атрибутов
    /// Позиционный параметр - AttributeTargets, определяет элемент программы 
    /// для которых атрибут может быть применен.
    /// Параметр - AttributeTargets.All - позволяет использовать атрибут - MyAttribute
    /// для  любого элемента.
    /// Именованный параметр - AllowMultiple = false, определяет сколько раз к одному элементу 
    /// можно применять атрибут.
    /// </summary>
    [AttributeUsage(AttributeTargets.All /* | AttributeTargets.Method*/, AllowMultiple =false)]
    class MyAttribute : System.Attribute
    {
        private readonly string date;
        public string Date { get { return date; } }

        // Позиционный параметр
        public MyAttribute(string date)
        {
            this.date = date;
        }

        // Именнованный параметр (нестатические поля или свойства)
        public int Number { get; set; }

    }

    [My("class Myclass", Number =444)]
    class Myclass
    {
        [My("public void Method()", Number = 333)]
        public void Method()
        {

        }

    }

    class Go
    {
        public Go()
        {
            Myclass myclass = new Myclass();
            myclass.Method();

            //Анализ атрибутов

            Type type = typeof(Myclass);

            // Получаем все аттрибутты заданного типа MyAtribute
            // (false- без проверки базовых классов)

            object[] attributes = type.GetCustomAttributes(false);

            foreach (MyAttribute item in attributes)
            {
                Console.WriteLine($"{item.Date}  {item.Number}");
            }


            // Анализ атрибутов метода
            MethodInfo method = type.GetMethod("Method", BindingFlags.Public | BindingFlags.Instance);
            attributes = method.GetCustomAttributes(typeof(MyAttribute), false);

            foreach (MyAttribute item in attributes)
            {
                Console.WriteLine($"{item.Date}  {item.Number}");
            }

            Console.ReadLine();
        }
    }
}
