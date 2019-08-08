using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.LINQs
{
    class _010_Linq
    {
        public class EmployeeID
        {
            public string ID { get; set; }
            public string Name { get; set; }
        }

        public _010_Linq()
        {
            // сотрудники
            List<EmployeeID> employees = new List<EmployeeID>
            {
                new EmployeeID() {ID="111",Name="IVAN" },
                new EmployeeID() {ID="222",Name="ANDREY" },
                new EmployeeID() {ID="333",Name="PETR" },
                new EmployeeID() {ID="444",Name="ALEX" }
            };

            var query = from x in employees
                        let str = $"ID = '{x.ID}' Name='{x.Name}'" //Локальный идентификатор
                        orderby str descending
                        select str;

            foreach (var item in query)
            {
                Console.WriteLine(item);
            }
        }
    }
}
