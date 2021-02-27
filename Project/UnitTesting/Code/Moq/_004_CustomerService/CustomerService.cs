using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Moq._004_CustomerService.Classes;
using Code.Moq._004_CustomerService.Interfaces;

namespace Code.Moq._004_CustomerService
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IIdFactory idFactory;

        public CustomerService(IIdFactory idFactory, ICustomerRepository customerRepository)
        {
            this.idFactory = idFactory;
            this.customerRepository = customerRepository;
        }

        public void Create(IEnumerable<CustomerDTO> customerDTOs)
        {
            foreach (var item in customerDTOs)
            {
                Customer newCustomer = new Customer(item.FirstName, item.LastName);

                newCustomer.Id = idFactory.Create();

                customerRepository.Save(newCustomer);
            }
        }
    }
}
