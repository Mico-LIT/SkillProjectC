using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.Collections
{
    class _001_List
    {
        public _001_List()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>
            {
                new EmployeeModel{Name="Alex"},
                new EmployeeModel{Name="Misha"},
                new EmployeeModel{Name="Ivan"},
            };

            for (int i = 0; i < employees.Count; i++)
            {
                Console.WriteLine(employees[i].Name);
            }

            foreach (var item in employees)
            {
                Console.WriteLine(item.Name);
            }

            employees.Add(new EmployeeModel() { Name = "Victor" });

            foreach (var item in employees)
            {
                Console.WriteLine(item.Name);
            }
        }
    }
}
