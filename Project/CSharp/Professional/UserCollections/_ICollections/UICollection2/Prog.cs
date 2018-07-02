using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.UserCollections._ICollection.UICollection2
{
    class Prog
    {
        public Prog()
        {
            UserCollection<int> coll = new UserCollection<int> { 1, 2, 3 };

            foreach (var item in coll)
            {
                Console.WriteLine(item);
            }

            coll.Contains(2);

            Console.ReadLine();
        }
    }
}
