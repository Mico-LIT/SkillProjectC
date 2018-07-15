using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.Serealizations.Binary
{
    [Serializable]
    class Mersedes : Car
    {
        protected Mode mode;

        public Mersedes(string name, int speed,Mode mode) : base(name, speed)
        {
            this.mode = mode;
        }

        public void ShowMode()
        {
            Console.WriteLine(mode);
        }

        public void SetMode(Mode mode)
        {
            this.mode = mode;
            Console.WriteLine($"{this.mode}");
        }
    }
}
