using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.DesignPatterns.Generative.AbstractFactory
{
    public class _01_Start
    {
        public _01_Start()
        {
            Client client = null;

            client = new Client(new Factory1());
            client.Run();
        }
    }
}
