using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.UserCollections._Collection.Collection
{
    class Prog
    {
        public Prog()
        {
            UserCollection coll = new UserCollection();
            coll[0] = new Element(1, 2);
            coll[1] = new Element(2, 3);
            coll[2] = new Element(3, 4);
            coll[3] = new Element(5, 6);

            foreach (Element item in coll)
            {
                Console.WriteLine($"{item.FildA} {item.FildB}");
            }

            // Так работает foreach

            IEnumerator enumer = (coll as IEnumerable).GetEnumerator();

            while (enumer.MoveNext())
            {
                Element item = enumer.Current as Element;
                Console.WriteLine($"{item.FildA} {item.FildB}");
            }

            Console.ReadLine();
        }
    }
}
