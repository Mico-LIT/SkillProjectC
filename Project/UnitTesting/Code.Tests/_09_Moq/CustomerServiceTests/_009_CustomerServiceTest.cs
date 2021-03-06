using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Code.Moq._009_CustomerService.Classes;
using Code.Moq._009_CustomerService.Interfaces;
using Code.Moq._009_CustomerService;

namespace Code.Tests._09_Moq.CustomerServiceTests
{
    /// <summary>
    /// MockingThrows
    /// </summary>
    [TestClass]
    public class _009_CustomerServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void Create_AddressCreate_ExpectedException()
        {
            // Aggregate
            var moqCustomerRepository = new Mock<ICustomerRepository>();
            var moqCustomerAddressFactory = new Mock<ICustomerAddressFactory>();

            var customerDto = new CustomerDTO() { FirstName = "1", LastName = "2"};

            moqCustomerAddressFactory
                .Setup(x => x.CreateFrom(It.IsAny<CustomerDTO>()))
                .Throws(new ArgumentNullException());

            CustomerService customerService = new CustomerService(moqCustomerAddressFactory.Object, moqCustomerRepository.Object);
            
            // Act
            customerService.Create(customerDto);
        }
    }
}
