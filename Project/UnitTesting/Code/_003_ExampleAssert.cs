using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    public class _003_ExampleAssert
    {
        public int Sum(int x, int y)
        {
            return x + y;
        }

        public static double GetSqrt(double value)
        {
            return Math.Sqrt(value);
        }

        public string SeyHello(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("parameter name cannot be null");

            return "Hello " + name;
        }
    }
}
