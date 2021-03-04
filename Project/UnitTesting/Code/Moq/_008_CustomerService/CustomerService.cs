using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Moq._008_CustomerService.Classes;
using Code.Moq._008_CustomerService.Interfaces;

namespace Code.Moq._008_CustomerService
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ICustomeStatusFactory customeStatusFactory;

        public CustomerService(ICustomeStatusFactory customeStatusFactory, ICustomerRepository customerRepository)
        {
            this.customeStatusFactory = customeStatusFactory;
            this.customerRepository = customerRepository;
        }

        public void Create(CustomerDTO customerDTO)
        {
            Customer newCustomer = new Customer(customerDTO.FirstName, customerDTO.LastName);

            newCustomer.StatusLevel = customeStatusFactory.CreateFrom(customerDTO);

            if (newCustomer.StatusLevel == StatusLevel.Gold)
                customerRepository.SaveExtended(newCustomer);
            else
                customerRepository.Save(newCustomer);
        }
    }
}
