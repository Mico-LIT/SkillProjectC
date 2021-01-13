using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.CollectitModels
{
    class _001_
    {
        class Employee { public string Name { get; set; } }

        class EmployeeComparer : IEqualityComparer<Employee>, IComparer<Employee>
        {
            public int Compare(Employee x, Employee y)
            {
                return string.Compare(x.Name, y.Name);
            }

            public bool Equals(Employee x, Employee y)
            {
                return string.Equals(x.Name, y.Name);
            }

            public int GetHashCode(Employee obj)
            {
                return obj.Name.GetHashCode();
            }
        }

        class DepartmentsCollections : SortedDictionary<string, SortedSet<Employee>>
        {
            public DepartmentsCollections Add(string departments, Employee employee)
            {
                if (!ContainsKey(departments))                
                    Add(departments, new SortedSet<Employee>(new EmployeeComparer()));                

                this[departments].Add(employee);
                return this;
            }

        }

        public _001_()
        {
            {
                var departments = new SortedDictionary<string, SortedSet<Employee>>();

                departments.Add("Sales", new SortedSet<Employee>(new EmployeeComparer()));
                departments["Sales"].Add(new Employee() { Name = "Misha" });
                departments["Sales"].Add(new Employee() { Name = "Viktor" });
                departments["Sales"].Add(new Employee() { Name = "Ira" });

                departments.Add("Programmers", new SortedSet<Employee>(new EmployeeComparer()));
                departments["Programmers"].Add(new Employee() { Name = "Misha" });
                departments["Programmers"].Add(new Employee() { Name = "Andrei" });
                departments["Programmers"].Add(new Employee() { Name = "Pasha" });
                departments["Programmers"].Add(new Employee() { Name = "Pasha" });

                foreach (var dep in departments)
                {
                    Console.WriteLine($"{dep.Key}:");
                    foreach (var employees in dep.Value)
                        Console.WriteLine($"\t {employees.Name}");
                }
            }

            {
                var departments = new DepartmentsCollections();

                departments.Add("Sales", new Employee() { Name = "Misha" })
                            .Add("Sales", new Employee() { Name = "Viktor" })
                            .Add("Sales", new Employee() { Name = "Ira" });

                departments.Add("Programmers", new Employee() { Name = "Misha" })
                            .Add("Programmers", new Employee() { Name = "Andrei" })
                            .Add("Programmers", new Employee() { Name = "Pasha" })
                            .Add("Programmers", new Employee() { Name = "Pasha" });

                foreach (var dep in departments)
                {
                    Console.WriteLine($"{dep.Key}:");
                    foreach (var employees in dep.Value)
                        Console.WriteLine($"\t {employees.Name}");
                }
            }
        }
    }
}
