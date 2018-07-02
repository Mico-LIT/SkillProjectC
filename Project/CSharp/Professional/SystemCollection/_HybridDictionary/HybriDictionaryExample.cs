using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.SystemCollection._HybridDictionary
{
    // HybridDictionary - Рекомендуется к использованию в тех случаях, когда невозможно определить размер коллекции
    class HybriDictionaryExample
    {
        public HybriDictionaryExample()
        {
            var emailLookup = new HybridDictionary();

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
