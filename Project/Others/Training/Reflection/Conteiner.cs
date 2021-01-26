using System;
using System.Collections.Generic;
using System.Text;

namespace Reflection
{
    public class Conteiner
    {
        public Conteiner()
        {
        }

        public Conteiner For<T>()
        {
            return this;
        }

        public Conteiner Use<T>()
        {
            return this;
        }

        public object Resolve<T>()
        {
            throw new NotImplementedException();
        }
    }
}
