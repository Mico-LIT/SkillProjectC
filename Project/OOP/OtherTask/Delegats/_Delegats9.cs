using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Delegats9
{
    class _Delegats9
    {
        Action<int, int> DelegatAction;
        Predicate<int> DelegatPredic;
        Func<int, double> DelegatFunc;

        public _Delegats9()
        {
            DelegatAction = Method;
            DelegatAction.Invoke(1, 2);

            DelegatPredic = delegate (int t) { return t > 0; };
            Console.WriteLine(DelegatPredic(1));

            DelegatFunc = Method1;
            DelegatFunc(2);

            Console.ReadLine();
        }

        void Method(int t,int t1)
        {
            Console.WriteLine($"{t+t1}");
        }

        double Method1(int t)
        {
            double ret = t * 1.23;
            Console.WriteLine(ret);
            return ret;
        }
    }
}
