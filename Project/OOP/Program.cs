using OOP.Task1._1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game();
        }

        void Game()
        {
            Console.SetWindowSize(100, 50);
            OtherTask.Game.Game asd = new OtherTask.Game.Game();
            asd.Run();
            ///Console.CursorVisible = true;
            Console.ReadLine();
        }
    }
}
