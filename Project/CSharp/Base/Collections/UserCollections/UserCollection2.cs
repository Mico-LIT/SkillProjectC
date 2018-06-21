using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Collections.UserCollections
{
    class UserCollection2
    {
       public static IEnumerable Power()
        {
            for (int i = 0; i < 10; i++)
            {
                yield return  $"{i}";
            }
        }
    }
}
