using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;


namespace CSharp.Professional.SystemCollection._ListDictionary
{
    // ListDictionary - Подходит для хранения небольшого количества элементов
    // поскольку оргпнизована по принципу обычного массива

    class ListDictionaryExample
    {
        public ListDictionaryExample()
        {
            var emailLookup = new ListDictionary();

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
