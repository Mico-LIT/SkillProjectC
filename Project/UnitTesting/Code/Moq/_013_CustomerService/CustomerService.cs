using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Moq._013_CustomerService.Classes;
using Code.Moq._013_CustomerService.Interfaces;

namespace Code.Moq._013_CustomerService
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IEmailFormatter emailFormatter;

        public CustomerService(IEmailFormatter emailFormatter, ICustomerRepository customerRepository)
        {
            this.emailFormatter = emailFormatter;
            this.customerRepository = customerRepository;

        }

        public void Create(IEnumerable<CustomerDTO> customerDTOs)
        {
            foreach (var item in customerDTOs)
            {
                customerRepository.Save(new Customer() { FirstName = item.FirstName, LastName = item.LastName });
                emailFormatter.CreateMessage(item.Email);
            }
        }
    }
}
