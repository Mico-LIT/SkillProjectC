using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.TasksByOOP.Games
{
    class Road
    {
        int left = 0;
        int top = 0;
        int speed = 0;

        public int Speed
        {
            set
            {
                if (value != 0)
                {
                    speed = 10000 / value;
                }
                else speed = value;
            }
        }
        public Road(int left = 30, int top = 0)
        {
            this.left = left;
            this.top = top;
        }

        public void Movie()
        {
            Thread th = new Thread(DrowSprint);
            th.Start();
            th.IsBackground = true;
        }

        void DrowSprint()
        {
            while (true)
            {
                if (this.speed !=0)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        top = i;

                        // очистка старой полосы
                        for (int e = 0; e < 45; e++)
                        {
                            Console.BackgroundColor = ConsoleColor.Black;

                            Console.SetCursorPosition(left,e); // левая
                            Console.Write(" ");

                            Console.SetCursorPosition(left+35, e); // правая
                            Console.Write(" ");
                        }

                        // Новая полоса 
                        for (int s = 0; s < 15; s++)
                        {
                            Console.BackgroundColor = ConsoleColor.Gray;

                            Console.SetCursorPosition(left, top);
                            Console.Write(" ");

                            Console.SetCursorPosition(left + 35, top);
                            Console.Write(" ");

                            top += 3;
                            Console.BackgroundColor = ConsoleColor.Black;
                        }

                        Thread.Sleep(this.speed);
                    }
                }
            }

        }
    }
}
