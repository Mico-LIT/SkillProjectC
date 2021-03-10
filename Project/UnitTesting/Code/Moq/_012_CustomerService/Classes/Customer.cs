using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Moq._012_CustomerService.Classes
{
    public class Customer
    {
        public Customer(){}

        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? WorkId { get; set; }
        public string WorkspaceName { get; set; }
    }
}
