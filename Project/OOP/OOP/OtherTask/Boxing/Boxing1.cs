using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Boxing
{
    class Boxing1
    {
       public Boxing1()
        {
            short s = 25;

            object obj = s;

            short s1 = (short)obj;

        }
    }
}
