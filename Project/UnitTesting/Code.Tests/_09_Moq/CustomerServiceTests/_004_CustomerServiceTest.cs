using Code.Moq._004_CustomerService.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Code.Moq._004_CustomerService;
using Code.Moq._004_CustomerService.Classes;

namespace Code.Tests._09_Moq.CustomerServiceTests
{
    [TestClass]
    public class _004_CustomerServiceTest
    {
        [TestMethod]
        public void Create_generaitNewCustomerId_SaveRepository()
        {
            // Aggregate
            var moqCustomerRepository = new Mock<ICustomerRepository>();
            var moqIdFactory = new Mock<IIdFactory>();

            var customerService = new CustomerService(moqIdFactory.Object, moqCustomerRepository.Object);

            var CustomerDTOs = new List<CustomerDTO>()
            {
                new CustomerDTO(){ FirstName="1", LastName="2" },
                new CustomerDTO(){ FirstName="2", LastName="2" },
                new CustomerDTO(){ FirstName="3", LastName="3" },
            };

            Guid guid = Guid.NewGuid();
            
            moqIdFactory
                .Setup(x => x.Create())
                .Returns(() => guid)
                .Callback(() => guid = Guid.NewGuid());

            // Act
            customerService.Create(CustomerDTOs);

            // Assert
            moqCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()));
            moqIdFactory.Verify(x => x.Create(), Times.AtLeastOnce);
            moqIdFactory.Verify(x => x.Create(), Times.AtLeast(3));
        }
    }
}
