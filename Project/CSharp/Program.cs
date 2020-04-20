using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Game();


            Console.Read();
        }

        void Game()
        {
            Console.SetWindowSize(100, 50);
            Games.Game asd = new Games.Game();
            asd.Run();
            ///Console.CursorVisible = true;
            Console.ReadLine();
        }
    }
}
