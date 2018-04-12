using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Game
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

        void Movie()
        {

        }
    }
}
