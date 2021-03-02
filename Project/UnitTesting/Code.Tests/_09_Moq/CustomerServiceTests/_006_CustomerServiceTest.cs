using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Code.Moq._006_CustomerService.Interfaces;
using Code.Moq._006_CustomerService.Classes;
using Code.Moq._006_CustomerService;

namespace Code.Tests._09_Moq.CustomerServiceTests
{
    /// <summary>
    /// Attribute ExpectedException and Returns on mock
    /// </summary>
    [TestClass]
    public class _006_CustomerServiceTest
    {
        [TestMethod]
        public void Create_SaveCustomer()
        {
            // Aggregate
            var mockEmailAddressFactory = new Mock<IEmailAddressFactory>();
            var mockCustomerRepository = new Mock<ICustomerRepository>();

            var customerService = new CustomerService(mockEmailAddressFactory.Object, mockCustomerRepository.Object);

            CustomerDTO customerDTO = new() { FirstName = "1", LastName = "2" };
            Address address = new();

            mockEmailAddressFactory
                .Setup(x => x.TryParse(It.IsAny<string>(), out address))
                .Returns(() => true);

            // Act
            customerService.Create(customerDTO);

            // Assert
            mockCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_SaveCustomer_ExpectedArgumentNullException()
        {
            // Aggregate
            var mockEmailAddressFactory = new Mock<IEmailAddressFactory>();
            var mockCustomerRepository = new Mock<ICustomerRepository>();

            var customerService = new CustomerService(mockEmailAddressFactory.Object, mockCustomerRepository.Object);

            CustomerDTO customerDTO = new() { FirstName = "1", LastName = "2" };
            Address address = null;

            mockEmailAddressFactory
                .Setup(x => x.TryParse(It.IsAny<string>(), out address))
                .Returns(() => false);

            // Act
            customerService.Create(customerDTO);
        }
    }
}
