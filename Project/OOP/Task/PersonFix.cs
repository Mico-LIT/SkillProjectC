using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.Task
{
    public class PersonFix : WorkflowBase
    {
        public PersonFix(int id, string name, double rate) : base(id, name, rate)
        {
        }

        public override double Salary => Rate;
    }
}
