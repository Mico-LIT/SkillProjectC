using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.SystemCollection._Hashtable
{
    class HashtableExample3
    {
        class Fish
        {
            public Fish(string name)
            {
                this.Name = name;
            }
            public string Name { get; set; }

            public override int GetHashCode()
            {
                return Name.GetHashCode();
            }

            public override bool Equals(object obj)
            {
                var tmp = obj as Fish;

                if (tmp == null) return false;

                return tmp.Name == Name;
            }
        }
        public HashtableExample3()
        {
            var emailLookup = new Hashtable();

            var key1 = new Fish("Herring");
            var key2 = new Fish("Herring1");
            var key3 = new Fish("Herring");

            //GetHashCode()
            emailLookup[key1] = "Hi";
            emailLookup[key2] = "Hi2";
            emailLookup[key3] = "Hi3";

            Console.WriteLine(emailLookup.Count);
            Console.ReadLine();
        }
    }
}
