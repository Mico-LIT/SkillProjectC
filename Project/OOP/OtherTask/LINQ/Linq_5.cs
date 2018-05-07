using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.LINQ
{
    class Linq_5
    {
        public Linq_5()
        {
            // Конструкция From похожа на оператор foreach
            // Использование нескольких конструкций from, аналогично вложенным операторам foreach

            var query = from x in Enumerable.Range(1, 9)
                        from y in Enumerable.Range(1, 10)
                        select new
                        {
                            X = x,
                            Y = y,
                            Prod = x * y
                        };

            foreach (var item in query)
            {
                Console.WriteLine($"{item.X }* {item.Y} = {item.Prod}");
            }

            Console.ReadLine();
        }
    }
}
