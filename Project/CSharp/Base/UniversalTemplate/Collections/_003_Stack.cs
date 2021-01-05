using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.Collections
{
    class _003_Stack
    {
        public _003_Stack()
        {
            Stack<EmployeeModel> employees = new Stack<EmployeeModel>();
            employees.Push(new EmployeeModel() { Name = "1" });
            employees.Push(new EmployeeModel() { Name = "2" });
            employees.Push(new EmployeeModel() { Name = "3" });

            var employeeModel = employees.Peek();
            employeeModel = employees.Pop();
        }
    }
}
