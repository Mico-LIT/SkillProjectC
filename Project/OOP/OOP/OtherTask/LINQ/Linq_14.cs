using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.LINQ
{
    class Linq_14
    {
        class Employee
        {
            public string FistName { get; set; }
            public string LastName { get; set; }
            public string Nationality { get; set; }
        }

        public Linq_14()
        {
            List<Employee> emp = new List<Employee>()
            {
                new Employee(){FistName="Ivan",LastName="VermanRUS",Nationality="RUS"},
                new Employee(){FistName="Mico",LastName="VermanRUS",Nationality="RUS"},
                new Employee(){FistName="Pety",LastName="VermanUKR",Nationality="UKR"},
                new Employee(){FistName="Ira",LastName="VermanUSA",Nationality="USA"}
            };

            var query = from x in emp
                        group x by new {  x.Nationality };

            foreach (var item in query)
            {
                Console.WriteLine(item.Key);

                foreach (var item2 in item)
                {
                    Console.WriteLine(item2.FistName);
                }
            }

            Console.ReadLine();
        }
    }
}
