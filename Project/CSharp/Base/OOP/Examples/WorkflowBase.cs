using System.Security.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.OOP.Examples
{
    public abstract class WorkflowBase
    {
        public double Rate;
        public string Name { get; set; }
        public int Id { get; set; }

        public abstract double Salary { get; }
        public WorkflowBase(int id, string name, double rate)
        {
            this.Id = id;
            this.Name = name;
            this.Rate = rate;
        }
        public WorkflowBase() { }

    }
}
