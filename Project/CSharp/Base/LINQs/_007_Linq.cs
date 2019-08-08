using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.LINQs
{
    class _007_Linq
    {
        public class EmployeeID
        {
            public string ID { get; set; }
            public string Name { get; set; }

        }

        public class EmployeeNationality
        {
            public string ID { get; set; }
            public string Nationality { get; set; }

        }

        public _007_Linq()
        {
            // сотрудники
            List<EmployeeID> employees = new List<EmployeeID>
            {
                new EmployeeID() {ID="111",Name="IVAN" },
                new EmployeeID() {ID="222",Name="ANDREY" },
                new EmployeeID() {ID="333",Name="PETR" },
                new EmployeeID() {ID="444",Name="ALEX" }
            };

            // национальности
            List<EmployeeNationality> empNati = new List<EmployeeNationality>()
            {
                new EmployeeNationality() { ID="111",Nationality="RUS" },
                new EmployeeNationality() { ID="222",Nationality="UKR" },
                new EmployeeNationality() { ID="333",Nationality="USA" }
            };

            var query = // переменная диапазона
                        from emp in employees
                        join n in empNati on emp.ID equals n.ID
                        orderby n.Nationality ascending //descending
                        select new
                        {
                            ID = emp.ID,
                            Name = emp.Name,
                            Nationality = n.Nationality
                        };
            foreach (var item in query)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
