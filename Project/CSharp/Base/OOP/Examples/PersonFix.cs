using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.OOP.Examples
{
    [Serializable]
    public class PersonFix : WorkflowBase
    {
        /// <summary>
        /// PersonFix
        /// </summary>
        /// <param name="id">идентификатор</param>
        /// <param name="name">имя</param>
        /// <param name="rate">ставка</param>
        public PersonFix(int id, string name, double rate) : base(id, name, rate)
        {
        }

        public PersonFix() { }

        public override double Salary => Rate;
    }
}
