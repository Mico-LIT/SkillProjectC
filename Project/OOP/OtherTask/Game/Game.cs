using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Game
{
    class Game
    {
        Car car;

        public Game()
        {
            car = new Car(
                new EngineBMW(),
                new CarBody(44, 15)
                );
            //Console.SetWindowSize(100, 50);

            //Console.CursorVisible = true;

            //CarBody a = new CarBody(44,15);
            //a.Draw();

            //Console.ReadLine();
        }
    }
}
