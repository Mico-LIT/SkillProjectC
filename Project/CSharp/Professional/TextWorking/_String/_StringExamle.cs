using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.TextWorking._String
{
    class _StringExamle
    {
        public _StringExamle()
        {
            String s = "Hello";
            Console.WriteLine(s);
            Console.WriteLine(s.GetHashCode());
            s = s.Insert(2, "mm");
            //s[2]='m';
            Console.WriteLine(s);
            Console.WriteLine(GetHashCode());
            ///
            string s2 = new string('-', 20);
            ///
            s += s2;
            ///
            string s4 = 5.ToString();
            //
            string s5 = String.Format("{0} + {1} = {2}", 1, 2, 1 + 2);

            Console.ReadLine();
        }
    }
}
