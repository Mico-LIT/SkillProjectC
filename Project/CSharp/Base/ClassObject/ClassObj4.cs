using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.ClassObject
{
    class ClassObj4
    {
        class Point : Object
        {
            protected int x;
            protected int y;
            
            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
            public override bool Equals(object obj)
            {
                if (obj == null || this.GetType() != obj.GetType())
                return false;

                Point p = (Point)obj;
                return (this.x == p.x) && (this.y == p.y);
            }

            public override int GetHashCode()
            {
                return x ^ y;
            }
        }

        public ClassObj4()
        {
            Point p  = new Point(3, 1);
            Point p2 = new Point(3, 1);
            Point p3 = new Point(0, 0);

            Console.WriteLine(p.Equals(p2));

            Console.WriteLine(p.Equals(p3));
            Console.WriteLine(object.Equals(p2,p));

            Console.ReadLine();
        }
    }
}
