using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.DesignPatterns.Generative.AbstractFactory
{
    public class ProductB : AbstractProductB
    {
        public override void Interact(AbstractProductA apa)
        {
            Console.Write(this + "Interact with" + apa);
        }
    }
}
