using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.Collections
{
    class _006_Dictionary
    {
        public _006_Dictionary()
        {
            Dictionary<int, EmployeeModel> emloyeeDict = new Dictionary<int, EmployeeModel>();

            emloyeeDict.Add(2, new EmployeeModel() { Name = "Andre" });
            emloyeeDict.Add(1, new EmployeeModel() { Name = "Misha" });
           // emloyeeDict.Add(1, new EmployeeModel() { Name = "Andre" });  // Error

            foreach (var item in emloyeeDict)
            {
                Console.WriteLine("Key:{0} Value.Name:{1}", item.Key, item.Value.Name);
            }
        }
    }
}
