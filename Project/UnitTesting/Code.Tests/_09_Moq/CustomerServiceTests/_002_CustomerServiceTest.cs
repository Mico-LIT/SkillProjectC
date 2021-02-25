using Code.Moq._002_CustomerService.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Code.Moq._002_CustomerService.Interfaces;

namespace Code.Tests._09_Moq.CustomerServiceTests
{
    [TestClass]
    public class _002_CustomerServiceTest
    {
        [TestMethod]
        public void CreateMethod_Save_WasCalled()
        {
            // Aggregate
            var customerDTOs = new List<CustomerDTO>()
            {
                new CustomerDTO(){ FirstName = "1", LastName="1"},
                new CustomerDTO(){ FirstName = "2", LastName="2"},
                new CustomerDTO(){ FirstName = "3", LastName="3"},
            };

            var mockCustomerRepositoty = new Mock<ICustomerRepository>();
            // можно через настройки
            mockCustomerRepositoty.Setup(s => s.Save(It.IsAny<Customer>()));

            var customerService = new Moq._002_CustomerService.CustomerService(mockCustomerRepositoty.Object);

            // Act
            customerService.Create(customerDTOs);

            // Assert
            mockCustomerRepositoty.Verify();
        }

        [TestMethod]
        public void CreateMethod_Save_WasCalled_ThreeTimes()
        {
            // Aggrete
            var customerDTOs = new List<CustomerDTO>()
            {
                new CustomerDTO(){ FirstName = "1", LastName="1"},
                new CustomerDTO(){ FirstName = "2", LastName="2"},
                new CustomerDTO(){ FirstName = "3", LastName="3"},
            };

            var mockCustomerRepositoty = new Mock<ICustomerRepository>();
            var customerService = new Moq._002_CustomerService.CustomerService(mockCustomerRepositoty.Object);

            // Act
            customerService.Create(customerDTOs);

            // Assert
            // можно сразу
            mockCustomerRepositoty.Verify(s => s.Save(It.IsAny<Customer>()), Times.Exactly(3));
        }
    }
}
