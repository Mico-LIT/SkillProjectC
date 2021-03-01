using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Moq._005_CustomerService.Classes;
using Code.Moq._005_CustomerService;
using Code.Moq._005_CustomerService.Interfaces;
using Moq;

namespace Code.Tests._09_Moq.CustomerServiceTests
{
    /// <summary>
    /// Mock Проверка out параметра
    /// </summary>
    [TestClass]
    public class _005_CustomerServiceTest
    {
        [TestMethod]
        public void Create_ShouldSaveCustumer()
        {
            var moqCustomerRepository = new Mock<ICustomerRepository>();
            var moqEmailAddressFactory = new Mock<IEmailAddressFactory>();

            var customerService = new CustomerService(moqEmailAddressFactory.Object, moqCustomerRepository.Object);

            var customer = new CustomerDTO() { FirstName = "1", LastName = "2" };

            Address address = new Address();

            moqEmailAddressFactory
                .Setup(x => x.TryParse(It.IsAny<string>(), out address))
                .Returns(true);

            customerService.Create(customer);

            moqCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()),Times.Once);
        }

        // Проверка out параметра
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_ShouldSaveCustumer_ArgumentNullException()
        {
            var moqCustomerRepository = new Mock<ICustomerRepository>();
            var moqEmailAddressFactory = new Mock<IEmailAddressFactory>();

            var customerService = new CustomerService(moqEmailAddressFactory.Object, moqCustomerRepository.Object);

            var customer = new CustomerDTO() { FirstName = "1", LastName = "2" };

            Address address = null;

            moqEmailAddressFactory
                .Setup(x => x.TryParse(It.IsAny<string>(), out address))
                .Returns(true);

            customerService.Create(customer);
        }
    }
}
