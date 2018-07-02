using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.SystemCollection._Hashtable
{
    class HashtableExample4
    {
        class InsensetiveComparer : IEqualityComparer // Равенство
        {
            readonly CaseInsensitiveComparer comparer = new CaseInsensitiveComparer();

            public new bool Equals(object x, object y)
            {
                return comparer.Compare(x, y) == 0;
            }

            public int GetHashCode(object obj)
            {
                return obj.ToString().ToLowerInvariant().GetHashCode();
            }
        }
        public HashtableExample4()
        {
            var dehash = new Hashtable(new InsensetiveComparer());

            dehash["First"] = "1st";
            dehash["Second"] = "2nd";
            dehash["Third"] = "3rd";
            dehash["Fourth"] = "4th";
            dehash["fourth"] = "4TH!!";

            Console.ReadLine();
        }
    }
}
