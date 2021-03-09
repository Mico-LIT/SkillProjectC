using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Moq._011_CustomerService.Classes;
using Code.Moq._011_CustomerService.Interfaces;

namespace Code.Moq._011_CustomerService
{
    public class CustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IWorkSettings workSettings;

        public CustomerService(IWorkSettings workSettings, ICustomerRepository customerRepository)
        {
            this.workSettings = workSettings;
            this.customerRepository = customerRepository;
        }

        public void Create(CustomerDTO customerDTO)
        {
            Customer newCustomer = new Customer();

            newCustomer.Id = Guid.NewGuid();
            newCustomer.FirstName = customerDTO.FirstName;
            newCustomer.LastName = customerDTO.LastName;

            newCustomer.WorkId = workSettings.WorkId;
            newCustomer.WorkspaceName = workSettings.WorkspaceName;

            if (!newCustomer.WorkId.HasValue)
                throw new ArgumentNullException();

            if (string.IsNullOrWhiteSpace(newCustomer.WorkspaceName))
                throw new ArgumentNullException();

            customerRepository.Save(newCustomer);
        }
    }
}
