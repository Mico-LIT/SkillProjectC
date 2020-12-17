using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.DesignPatterns.Generative.AbstractFactory
{
    public class Client
    {
        AbstractProductA apa;
        AbstractProductB apb;

        public Client(AbstractFactory abstractFactory)
        {
            apa = abstractFactory.CreateProductA();
            apb = abstractFactory.CreateProductB();
        }

        public void Run()
        {
            apb.Interact(apa);
        }
    }
}
