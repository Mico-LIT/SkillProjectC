using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Game
{
    class Game
    {
        public Game()
        {
            Console.SetWindowSize(100, 50);

            Console.CursorVisible = true;

            CarBody a = new CarBody(44,15);
            a.Draw();

            Console.ReadLine();
        }
    }
}
