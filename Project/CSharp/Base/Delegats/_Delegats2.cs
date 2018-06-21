using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Delegats.Delegats2
{
    static public class Myclass2
    {
        static public string Method2(string str)
        {
            return ($"Hi {str}");
        }
    }

    public delegate string Mydelegate2(string s);
   public class _Delegats2
    {
        _Delegats2()
        {
            Mydelegate2 mydelegate2 = new Mydelegate2(Myclass2.Method2);

            Console.WriteLine(mydelegate2.Invoke("Mico"));

            Console.WriteLine(mydelegate2("Judi"));
        }

    }
}
