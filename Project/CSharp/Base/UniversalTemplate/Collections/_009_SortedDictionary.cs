using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.Collections
{
    class _009_SortedDictionary
    {
        public _009_SortedDictionary()
        {    
            // sorted by key
            SortedDictionary<int, EmployeeModel> keyValuePairs = new SortedDictionary<int, EmployeeModel>();
            keyValuePairs.Add(2, new EmployeeModel() { Name = "Andre" });
            keyValuePairs.Add(1, new EmployeeModel() { Name = "Misha" });

            foreach (var item in keyValuePairs)
            {
                Console.WriteLine("Key:{0} Value.Name:{1}", item.Key, item.Value.Name);
            }
        }
    }
}
