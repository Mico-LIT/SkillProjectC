using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CodeFirst.Models.Other
{
    public class Player
    {
        public int Id { get; set; }
        public int TeamId{ get; set; }
        public string Name { get; set; }
        public int Position { get; set; }
        public Team Team { get; set; }
    }
}
