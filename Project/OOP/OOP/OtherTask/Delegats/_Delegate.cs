using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Delegats
{
    static public class Myclass
    {
        static public void Method()
        {
            Console.WriteLine("Hi");
        }
    }

    delegate void Mydelegate();
    class _Delegate
    {
        _Delegate(){
            Mydelegate mydelegate = new Mydelegate(Myclass.Method);

            mydelegate.Invoke();

            // mydelegate();

            }
    }
}
