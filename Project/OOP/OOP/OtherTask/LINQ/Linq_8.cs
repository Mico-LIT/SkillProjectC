using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Orderby - Используется для сортировки (последовательности) результата запроса.
/// </summary>

namespace OOP.OtherTask.LINQ
{
    public class Employee
    {
        public string LastName { get; set; }
        public string FirstNmae { get; set; }
        public string Nationality { get; set; }
    }

    class Linq_8
    {
        public Linq_8()
        {
            List<Employee> emp = new List<Employee>()
            {
                 new Employee() { LastName="Ivanov" ,FirstNmae="Ivan", Nationality="RUS" }
                ,new Employee() { LastName="ANDREEV" ,FirstNmae="Andrew", Nationality="UKR" }
                ,new Employee() { LastName = "Petrov", FirstNmae = "Petr", Nationality = "USA" }
            };

            var query = from e in emp
                        orderby e.Nationality ascending, // ascending - по возврастанию | descending - по убыванию
                                e.LastName descending,
                                e.FirstNmae descending
                        select e;

            foreach (var item in query)
            {
                Console.WriteLine($"{item}");
            }
        }

    }
}
