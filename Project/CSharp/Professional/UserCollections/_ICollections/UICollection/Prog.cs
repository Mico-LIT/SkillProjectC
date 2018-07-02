using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.UserCollections._ICollection.UICollection
{
    class Prog
    {
        public Prog()
        {
            UserCollection coll = new UserCollection();

            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('_',2));

            var arr = new object[coll.Count];

            coll.CopyTo(arr, 0);

            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
