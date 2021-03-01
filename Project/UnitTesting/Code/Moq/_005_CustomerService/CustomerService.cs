using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Moq._005_CustomerService.Classes;
using Code.Moq._005_CustomerService.Interfaces;

namespace Code.Moq._005_CustomerService
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IEmailAddressFactory emailAddressFactory;

        public CustomerService(IEmailAddressFactory emailAddressFactory, ICustomerRepository customerRepository)
        {
            this.emailAddressFactory = emailAddressFactory;
            this.customerRepository = customerRepository;
        }

        public void Create(CustomerDTO customerDTO)
        {
            Customer newCustomer = new Customer(customerDTO.FirstName, customerDTO.LastName);
            newCustomer.Id = Guid.NewGuid();

            Address address;
            emailAddressFactory.TryParse(customerDTO.Email, out address);

            if (address == null)            
                throw new ArgumentNullException(nameof(address));            

            newCustomer.Email = address;           

            customerRepository.Save(newCustomer);
        }
    }
}
