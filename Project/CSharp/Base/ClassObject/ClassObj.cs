using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.ClassObject
{
    class ClassObj
    {
        class MyClassA : Object
        {

        }

        class MyClassB : object
        {

        }

        public ClassObj()
        {
            Object instanceA = new MyClassA();
            object instanceB = new MyClassB();
            
            Console.ReadLine();
        }
    }
}
