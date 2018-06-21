using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Operators
{
  
    class Operators
    {
        public struct Point
        {
            private int x, y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }

            public static bool operator ==(Point p1, Point p2)
            {
                return p1.Equals(p2);
            }

            public static bool operator !=(Point p1, Point p2)
            {
                return !p1.Equals(p2);
            }

            public override string ToString()
            {
                return $"x={this.x} y={this.y}";
            }

            public override bool Equals(object obj)
            {
                if (obj is Point)
                {
                    if (((Point)obj).x == this.x && ((Point)obj).y == this.y)
                        return true;
                }
                return false;
            }

            public override int GetHashCode()
            {
                return this.ToString().GetHashCode();
            }

        }

        public Operators()
        {
            Point a = new Point(1,1);
            Point b = new Point(2, 2);

            Console.WriteLine(" a == b = ", a == b);
            Console.WriteLine(" a != b = ", a != b);

            Point c = new Point(1, 1);

            Console.WriteLine(" a == b = ", a == c);
            Console.WriteLine(" a != b = ", a != c);
        }
    }
}
