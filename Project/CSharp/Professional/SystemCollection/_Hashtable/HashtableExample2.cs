using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.SystemCollection._Hashtable
{
    class HashtableExample2
    {
        public HashtableExample2()
        {
            var emailLookup = new Hashtable();

            emailLookup["testte@email.com"] = "Bishop, Scott";
            emailLookup["wwwe122@gmail.com"] = "Hell, Christian";
            emailLookup["djump@contoso.com"] = "Jump, Dan";

            foreach (object item in emailLookup)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('_',20));

            foreach (DictionaryEntry item in emailLookup)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('_', 20));

            foreach (object item in emailLookup.Keys)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
