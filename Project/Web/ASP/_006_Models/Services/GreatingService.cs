using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _006_Models.Services
{
    public class GreatingService : IGreating
    {
        public string Greet()
        {
            return "Hi User";
        }
    }
}
