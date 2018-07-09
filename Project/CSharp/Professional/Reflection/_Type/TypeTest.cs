using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.Reflection._Type
{
    class MyClass
    {
    }

    class TypeTest
    {
        public TypeTest()
        {
            //1
            Type type;
            MyClass myClass = new MyClass();
            type = myClass.GetType();
            Console.WriteLine("1 Way " + type);
            //2
            type = Type.GetType("CSharp.Professional.Reflection._Type.MyClass");
            Console.WriteLine("2 way "+ type);
            //3
            type = typeof(MyClass);
            Console.WriteLine("3 way "+ type);

            Console.ReadLine();
        }
    }
}
