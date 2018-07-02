using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.SystemCollection._OrderedDictionary
{
    /// <summary>
    /// OrderedDictionary - Размещение элементов соответствует порядку их добавления в коллекцию,
    /// что позволяет автоматически сохрянять элементы в хронологическом порядке
    /// </summary>
    class OrderedDictionaryExample
    {
        public OrderedDictionaryExample()
        {
            var emailLookup = new OrderedDictionary();

            emailLookup["testte@email.com"] = "Bishop, Scott";
            emailLookup["wwwe122@gmail.com"] = "Hell, Christian";
            emailLookup["djump@contoso.com"] = "Jump, Dan";

            foreach (DictionaryEntry item in emailLookup)
            {
                Console.WriteLine(item.Value);
            }

        }
    }
}
