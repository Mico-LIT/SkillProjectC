using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Moq._007_CustomerService.Classes;
using Code.Moq._007_CustomerService.Interfaces;

namespace Code.Moq._007_CustomerService
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly INameBuilder nameBuilder;

        public CustomerService(INameBuilder nameBuilder, ICustomerRepository customerRepository)
        {
            this.nameBuilder = nameBuilder;
            this.customerRepository = customerRepository;
        }

        public void Create(CustomerDTO customerDTO)
        {
            string fullName = nameBuilder.From(customerDTO.FirstName, customerDTO.LastName);

            Customer newCustomer = new Customer(fullName);
            newCustomer.Id = Guid.NewGuid();

            customerRepository.Save(newCustomer);
        }
    }
}
