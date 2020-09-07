using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Games
{
    class Game
    {
        Car car;
        Road road;

        public Game()
        {
            Console.SetWindowSize(100, 50);
            car = new Car(new EngineBMW(), new CarBody(40, 20));
            road = new Road();

            ///Console.CursorVisible = true;
            this.Run();
            Console.ReadLine();
        }

        public void Run()
        {
            car.Show();
            road.Movie();

            while (true)
            {
                try
                {
                    Thread.Sleep(1000);
                    road.Speed = car.Accelerator(10);
                }
                catch (Exception)
                {

                    //throw;
                }
            }

        }
    }
}
