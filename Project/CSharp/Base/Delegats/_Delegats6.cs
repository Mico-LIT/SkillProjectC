using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Delegats.Delegats6
{
    public delegate Mydelegats Mydelegats2();
    public delegate void Mydelegats();
    class _Delegats6
    {
        Mydelegats Method()
        {
            return new Mydelegats(MethodCW);
        }

        void MethodCW()
        {
            Console.WriteLine("Hi");
        }

        public _Delegats6()
        {
            Mydelegats2 mydelegats2 = new Mydelegats2(Method);
            Mydelegats mydelegats = mydelegats2();
            mydelegats.Invoke();

        }
    }
}
