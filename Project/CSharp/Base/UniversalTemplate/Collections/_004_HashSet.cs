using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.Collections
{
    class _004_HashSet
    {
        public _004_HashSet()
        {

            HashSet<EmployeeModel> employees = new HashSet<EmployeeModel>();
            var employeeMisha = new EmployeeModel() { Name = "Misha" };
            employees.Add(employeeMisha);
            employees.Add(employeeMisha);
            employees.Add(new EmployeeModel() { Name = "Ivan" });
            employees.Add(new EmployeeModel() { Name = "Peta" });

            foreach (var item in employees)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine(new string('_', 20));

            IEnumerable<EmployeeModel> employeeModels = new List<EmployeeModel>()
            {
                new EmployeeModel(){Name="Andrei"},
                new EmployeeModel(){Name="Danil"},
            };

            employees.UnionWith(employeeModels);

            foreach (var item in employees)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine(new string('_', 20));

            employees.ExceptWith(employeeModels);

            foreach (var item in employees)
            {
                Console.WriteLine(item.Name);
            }

        }
    }
}
