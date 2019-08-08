using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.LINQs
{
    class _009_Linq
    {
        class Result
        {
            public int Input { get; set; }
            public int Output { get; set; }
            public Result(int input, int output)
            {
                this.Input = input;
                this.Output = output;
            }
        }

        public _009_Linq()
        {

            int[] numbers = { 1, 2, 3, 4 };

            var query = from x in numbers
                        select new Result(x, x * 2);

            //var query = from x in numbers
            //             select new { Output = x, Input = x * 2 };

            numbers[0] = 777;

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

        }
    }
}
