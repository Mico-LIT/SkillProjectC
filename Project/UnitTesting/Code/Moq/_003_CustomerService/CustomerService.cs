using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Moq._003_CustomerService.Classes;
using Code.Moq._003_CustomerService.Interfaces;

namespace Code.Moq._003_CustomerService
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IEmailBuilder emailBuilder;

        public CustomerService(IEmailBuilder emailBuilder, ICustomerRepository customerRepository)
        {
            this.emailBuilder = emailBuilder;
            this.customerRepository = customerRepository;
        }

        public void Create(CustomerDTO customerDTO)
        {
            Customer customer = new Customer(customerDTO.FirstName, customerDTO.LastName);

            // При тесте необходимо определить что вернул emailBuilder.From
            customer.Email = emailBuilder.From(customerDTO);

            if (customer.Email == null)            
                throw new ArgumentNullException(nameof(customer.Email));
            
            customerRepository.Save(customer);
        }
    }
}
