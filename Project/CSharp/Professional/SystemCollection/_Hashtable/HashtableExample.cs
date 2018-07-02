using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.SystemCollection._Hashtable
{
    // Hashtable - Используется когда много элементов

    class HashtableExample
    {
        public HashtableExample()
        {
            var emailLookup = new Hashtable();

            // Метод Add принимает в качестве первого параметра ключ ,
            // а в качестве второго - значение
            emailLookup.Add("sbishop@contoso.com", "Bishop, Scott");

            // Невозможно добавить элемент с уже имеющимся в хэш-таблице ключом.
            // emailLookup.Add("sbishop@contoso.com", "Bishop, Scott");

            // Особенности использования индексаторов

            // Использование индексаторов эквивалентно вызову add,
            // если такого индекса не сущевствует
            emailLookup["s.bishop@contoso.com"] = "Bishop, Scott";

            // замена
            emailLookup["sbishop@contoso.com"] = "______________";

            Console.WriteLine(emailLookup["sbishop@contoso.com"]);
            Console.WriteLine(emailLookup["s.bishop@contoso.com"]);
        }
    }
}
