using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Task
{
    public class PersonTime : WorkflowBase
    {
        public PersonTime(int id, string name, double rate) : base(id, name, rate)
        {
        }
        public override double Salary { get => 20.8 * 8 * Rate; }
    }
}
