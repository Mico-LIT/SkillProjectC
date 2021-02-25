using Code.Moq._002_CustomerService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Moq._002_CustomerService
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }

        public void Create(IEnumerable<Models.CustomerDTO> customerDTOs)
        {

            foreach (var item in customerDTOs)
            {
                customerRepository.Save(new Models.Customer(item.FirstName, item.LastName));
            }
        }
    }
}
