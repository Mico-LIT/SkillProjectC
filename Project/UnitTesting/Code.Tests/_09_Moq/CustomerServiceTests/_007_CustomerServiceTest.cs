using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Code.Moq._007_CustomerService.Interfaces;
using Code.Moq._007_CustomerService.Classes;
using Code.Moq._007_CustomerService;

namespace Code.Tests._09_Moq.CustomerServiceTests
{
    /// <summary>
    /// Verify Equals
    /// </summary>
    [TestClass]
    public class _007_CustomerServiceTest
    {
        [TestMethod]
        public void Create_CheckFullName()
        {
            var customerDto = new CustomerDTO()
            {
                FirstName = "1",
                LastName = "2"
            };

            var moqNameBuilder = new Mock<INameBuilder>();
            var moqCustomerRepository = new Mock<ICustomerRepository>();

            CustomerService customerService = new(moqNameBuilder.Object, moqCustomerRepository.Object);

            customerService.Create(customerDto);

            moqNameBuilder
                .Verify(x => x.From(
                    It.Is<string>(x => x.Equals(customerDto.FirstName)),
                    It.Is<string>(x => x.Equals(customerDto.LastName))));
        }
    }
}
