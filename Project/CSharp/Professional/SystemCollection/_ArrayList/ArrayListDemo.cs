using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.SystemCollection._ArrayList
{
    class ArrayListDemo
    {
        public ArrayListDemo()
        {
            var list = new ArrayList();

            string s = "Hello";
            list.Add(s);
            list.Add("Hi");
            list.Add(50);
            list.Add(new object());

            // Добавление набора набора
            var anArray = new[] { "more", "or", "less" };
            list.AddRange(anArray);

            var anotherArray = new[] { new object(), new ArrayList() };
            list.AddRange(anotherArray);

            // Вставка элементов в заданное положение используется метод Insert.
            list.Insert(3, "Hey all");

            var moreString = new[] { "goodnight", "see ya" };
            list.InsertRange(4,moreString);

            list[3] = "Hey all 2";

            //Удаление из набора одиночных элементов используя метод Remove
            list.Add("Hello");
            list.Remove("Hello");

            list.RemoveAt(0);
            list.RemoveRange(0, 4);

            foreach (var item in list)
            {
                // Error
                //list.Remove(item);
                Console.WriteLine(item);
            }

        }
    }
}
