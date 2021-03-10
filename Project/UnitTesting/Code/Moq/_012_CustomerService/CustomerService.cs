using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Moq._012_CustomerService.Classes;
using Code.Moq._012_CustomerService.Interfaces;

namespace Code.Moq._012_CustomerService
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMalingRepository malingRepository;

        public CustomerService(IMalingRepository malingRepository, ICustomerRepository customerRepository)
        {
            this.malingRepository = malingRepository;
            this.customerRepository = customerRepository;

            this.customerRepository.Notify += CustomerRepository_Notify;
        }

        private void CustomerRepository_Notify(object sender, NotifiEventArg e)
        {
            malingRepository.CreateNewMessage(e.CustomerName);
        }

        public void Create(CustomerDTO customerDTO)
        {
            Customer newCustomer = new Customer();

            newCustomer.Id = Guid.NewGuid();
            newCustomer.FirstName = customerDTO.FirstName;
            newCustomer.LastName = customerDTO.LastName;

            if (!newCustomer.WorkId.HasValue)
                throw new ArgumentNullException();

            if (string.IsNullOrWhiteSpace(newCustomer.WorkspaceName))
                throw new ArgumentNullException();

            customerRepository.Save(newCustomer);
        }
    }
}
