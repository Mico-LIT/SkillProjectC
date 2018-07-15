using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.Serealizations.Binary
{
    [Serializable]
    class Radio
    {
        [NonSerialized]
        public int id = 9;

        internal void OnOff(bool state)
        { 
            Console.WriteLine(state ? "radio on":"radio off");
        }
    }
}
