using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.ClassObject
{
    class ClassObj3
    {
        public ClassObj3()
        {
            Object obj = new Object();
            Object obj1 = new Object();

            Console.WriteLine(obj.Equals(obj1));
            obj = obj1;
            Console.WriteLine(obj.Equals(obj1));

            Console.ReadLine();
        }
    }
}
