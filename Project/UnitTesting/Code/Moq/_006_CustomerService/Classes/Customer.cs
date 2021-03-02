using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Moq._006_CustomerService.Classes
{
    public class Customer
    {
        public Customer(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Address Email { get; set; }
    }
}
