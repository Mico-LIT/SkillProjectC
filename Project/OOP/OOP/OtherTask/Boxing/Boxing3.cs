using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Boxing
{
    interface Imystuct
    {
        void Method();
    }

    struct Mystruct : Imystuct
    {
        public void Method()
        {
            Console.WriteLine("Hi");
        }
    }

    public class Boxing3
    {
        public Boxing3()
        {
            Mystruct mystruct = new Mystruct();
            mystruct.Method();

            Imystuct boxing = mystruct;
            boxing.Method();

            Mystruct unboxing = (Mystruct)boxing;

            Console.ReadLine();
        }
    }
}
