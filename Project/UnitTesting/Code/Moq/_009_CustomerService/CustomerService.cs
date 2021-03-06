using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Moq._009_CustomerService.Classes;
using Code.Moq._009_CustomerService.Interfaces;

namespace Code.Moq._009_CustomerService
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly ICustomerAddressFactory addressFactory;

        public CustomerService(ICustomerAddressFactory addressFactory, ICustomerRepository customerRepository)
        {
            this.addressFactory = addressFactory;
            this.customerRepository = customerRepository;
        }

        public void Create(CustomerDTO customerDTO)
        {
            try
            {
                Customer newCustomer = new Customer();
                newCustomer.Id = Guid.NewGuid();
                newCustomer.FirstName = customerDTO.FirstName;
                newCustomer.LastName = customerDTO.LastName;

                newCustomer.Address = addressFactory.CreateFrom(customerDTO);

                customerRepository.Save(newCustomer);
            }
            catch (ArgumentNullException ex)
            {
                throw new NullReferenceException(ex.Message, ex);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
