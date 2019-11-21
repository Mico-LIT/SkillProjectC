using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Models.Other
{
    public class Airplane
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public int CountWheel { get; set; }
    }
}
