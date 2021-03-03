using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Moq._007_CustomerService.Classes
{
    public class Customer
    {
        public Customer(string fullName)
        {
            string tmp = fullName;
            Console.WriteLine($"{fullName}");
        }

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Email { get; set; }
    }
}
