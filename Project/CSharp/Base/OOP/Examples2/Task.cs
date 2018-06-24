using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.OOP.Examples2
{
    /// <summary>
    /// Есть машина и велосипед, у машины макс.скорость 300км/к, у велосипеда
    /// 40км/ч, надо реализовать соответсвующие классы и учесть, эти ограничения.
    /// Предпологаемый API
    /// new Car().Run(100);
    /// </summary>
    class Task
    {
        /// <summary>
        /// Средство передвижения
        /// </summary>
        public abstract class Vehicle
        {
            private int _speed;

            public int Speed {
                get { return _speed; }

                set {
                    if (GetType() == typeof(Bicycle))
                    {
                        if (value > 40) {
                            Console.WriteLine("MAX speed = 40 км/ч");
                            return;
                        }
                        _speed = value;
                    }
                    if (GetType() == typeof(Car))
                    {
                        if (value > 300)
                        {
                            Console.WriteLine("MAX speed = 300 км/ч");
                            return;
                        }
                        _speed = value;
                    }
                } }

            abstract public void Run(int speed);
        }

        /// <summary>
        /// Велосипед
        /// </summary>
        public class Bicycle : Vehicle
        {
            public override void Run(int speed)
            {
                base.Speed = speed;
            }
        }

        /// <summary>
        /// Машина
        /// </summary>
        public class Car : Vehicle
        {
            public override void Run(int speed)
            {
                base.Speed = speed;
            }
        }
    }
}
