using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Operators
{
    class Operators1
    {
        public struct Point
        {
            private int x, y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            // Использвоание слова operator, можно только вместе с ключевым словом static

            // Перегрузка оператора
            public static Point operator +(Point point1, Point point2)
            {
                return new Point(point1.x + point2.x, point1.y + point2.y);
            }

            public static Point operator ++(Point p)
            {
                return new Point(p.x + 1, p.y + 1);
            }

            public override string ToString()
            {
                return $"x={this.x} y={this.y}";
            }

        }

        public Operators1()
        {
            Point a = new Point(1,2);
            Point b = new Point(3,5);

            Point c = a +b;
            Console.WriteLine(c++);
            Console.WriteLine(c++);
            Console.WriteLine(++c);

            Console.WriteLine($"{c}");

            Console.ReadKey();
        }
    }
}
