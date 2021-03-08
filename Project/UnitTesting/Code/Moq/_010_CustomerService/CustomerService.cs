using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Moq._010_CustomerService.Classes;
using Code.Moq._010_CustomerService.Interfaces;

namespace Code.Moq._010_CustomerService
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

            int? workId = workSettings.WorkId;

            if (!workId.HasValue)            
                throw new ArgumentNullException();

            newCustomer.WorkId = workId.Value;

            // Тест должен проверить что свойство установлено
            customerRepository.LolacTimeZone = TimeZoneInfo.Local.DisplayName;

            customerRepository.Save(newCustomer);
        }
    }
}
