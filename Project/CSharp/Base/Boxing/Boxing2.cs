using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Boxing
{
    struct MyStruct //: ValueTyte
    {
       public void Method()
        {
            Console.WriteLine("EEE");
        }
    }

    public class Boxing2
    {
      public Boxing2()
        {
            MyStruct MyStruct = new MyStruct();

            ValueType boxed = MyStruct;

            MyStruct unboxed = (MyStruct)boxed;

            Console.ReadLine();
        }
    }
}
