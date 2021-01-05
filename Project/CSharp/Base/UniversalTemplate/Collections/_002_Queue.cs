using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.Collections
{
    class _002_Queue
    {
        public _002_Queue()
        {
            Queue<EmployeeModel> employees = new Queue<EmployeeModel>();
            employees.Enqueue(new EmployeeModel() { Name = "1" });
            employees.Enqueue(new EmployeeModel() { Name = "2" });
            employees.Enqueue(new EmployeeModel() { Name = "3" });

            foreach (var item in employees)
                Console.WriteLine(item.Name);
            // just see
            var employee = employees.Peek();

            foreach (var item in employees)
                Console.WriteLine(item.Name);
            //get and removed in queue
            employee = employees.Dequeue();

            foreach (var item in employees)
                Console.WriteLine(item.Name);
            //add in queue
            employees.Enqueue(new EmployeeModel() { Name = "22" });

        }
    }
}
