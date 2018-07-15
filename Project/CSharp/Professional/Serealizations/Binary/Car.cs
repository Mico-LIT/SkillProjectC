using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.Serealizations.Binary
{
    [Serializable]
    class Car
    {
        protected int speed;
        protected string name;
        protected Radio radio;

        public Car(string name , int speed)
        {
            this.name = name;
            this.speed = speed;
            radio = new Radio();
        }

        public int Speed { get { return speed; } set { speed = value; } }
        public string Name { get { return name; } set { name = value; } }

        public void OnRadio(bool state)
        {
            this.radio.OnOff(state);
        }


    }
}
