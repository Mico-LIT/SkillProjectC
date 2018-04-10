using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace OOP.OtherTask.Game
{
    class CarBody
    {
        int left;
        int top;

        public CarBody(int left, int top)
        {
            this.left = left;
            this.top = top;
        }

        public void Draw()
        {
            Thread th = new Thread(DrawCarBody);
            th.Start();
        }

        void DrawCarBody()
        {
            Console.SetCursorPosition(left, top);
            Console.BackgroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(" ");
                }
                top++;
                Console.SetCursorPosition(left,top);
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }


    }
}
