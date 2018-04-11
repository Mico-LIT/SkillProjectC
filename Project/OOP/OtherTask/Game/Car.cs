using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Game
{
    class Car
    {
        CarBody carbody;
        Engine engine;
        public Car(int left = 44,int top = 15)
        {
            engine = new Engine();
            carbody = new CarBody(left,top);
        }

        public void Show()
        {
            carbody.Draw();
        }

        public int Accelerator(int delta = 1)
        {
            return engine.Accelerator(delta);
        }

        public void Braking()
        {

        }
    }
}
