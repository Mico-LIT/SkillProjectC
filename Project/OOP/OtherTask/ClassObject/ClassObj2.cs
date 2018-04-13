using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.ClassObject
{
    class ClassObj2
    {
        class MyClass : Object
        {
            public override string ToString()
            {
                return "Hi";
            }
        }
         
        public ClassObj2()
        {
            MyClass my = new MyClass();

            Console.WriteLine(my);
            Console.ReadLine();
        }
    }
}
