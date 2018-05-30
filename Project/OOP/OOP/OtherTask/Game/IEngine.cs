using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Game
{
    interface IEngine
    {
        int Accelerator(int delta = 1);
        void Braking();
    }
}
