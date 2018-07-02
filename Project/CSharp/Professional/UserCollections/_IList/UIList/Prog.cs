using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.UserCollections._IList.UIList
{
    class Prog
    {
        public Prog()
        {
            UserCollection coll = new UserCollection();
            var i = coll.Add(1);
            Console.ReadLine();
        }
    }
}
