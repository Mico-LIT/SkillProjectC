using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Game
{
    class Car
    {
        ICarBody icarbody;
        IEngine iengine;

        public Car(IEngine engine, ICarBody carbody)
        {
            this.iengine = engine;
            this.icarbody = carbody;
        }

        public void Show()
        {
            icarbody.Draw();
        }

        public int Accelerator(int delta = 1)
        {
            return iengine.Accelerator(delta);
        }

        public void Braking()
        {
            iengine.Braking();
        }
    }
}
