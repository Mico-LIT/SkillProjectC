using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Собеседование_developer
{
    class Task_5
    {
        public Task_5()
        {
            var s1 = string.Format("{0}{1}", "abc", "cba");
            var s2 = "abc" + "cba";
            var s3 = "abccba";

            Console.WriteLine(s1 == s2);
            Console.WriteLine((object)s1 == (object)s2);
            Console.WriteLine(s2 == s3);
            Console.WriteLine((object)s2 == (object)s3);
            Console.ReadLine();

            ///
            //Варианты ответов:
            //true, false, true, true +
            //true, true, true, true
            //true, false, true, false
            //true, false, false, false
            ///
            //Если текущий экземпляр является ссылочным типом, 
            //    метод Equals(Object) проверяет равенство ссылок, 
            //и вызов метода Equals(Object) эквивалентен вызову метода 
            //    ReferenceEquals. Равенство ссылок означает, что 
            //    объектные переменные, которые сравниваются, 
            //    ссылаются на один и тот же объект.
        }
    }
}
