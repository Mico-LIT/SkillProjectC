using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Code.Moq._008_CustomerService.Classes;
using Code.Moq._008_CustomerService.Interfaces;
using Code.Moq._008_CustomerService;


namespace Code.Tests._09_Moq.CustomerServiceTests
{
    [TestClass]
    public class _008_CustomerServiceTest
    {
        [TestMethod]
        public void Create_CheckStatusLevelBronze_SaveCustomer()
        {
            // Aggregate
            var moqCustomerRepository = new Mock<ICustomerRepository>();
            var moqCustomeStatusFactory = new Mock<ICustomeStatusFactory>();

            var customerDto = new CustomerDTO() { FirstName = "1", LastName = "2", DesiredLevel = StatusLevel.Bronze };

            //moqCustomeStatusFactory
            //    .Setup(x => x.CreateFrom(It.IsAny<CustomerDTO>()))
            //    .Returns(StatusLevel.Gold);

            moqCustomeStatusFactory
                .Setup(x => x.CreateFrom(It.Is<CustomerDTO>(y => y.DesiredLevel == StatusLevel.Bronze)))
                .Returns(StatusLevel.Bronze);

            CustomerService customerService = new CustomerService(moqCustomeStatusFactory.Object, moqCustomerRepository.Object);

            // Act
            customerService.Create(customerDto);

            // Assert
            moqCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()));
        }

        [TestMethod]
        public void Create_CheckStatusLevelGold_SaveCustomer()
        {
            // Aggregate
            var moqCustomerRepository = new Mock<ICustomerRepository>();
            var moqCustomeStatusFactory = new Mock<ICustomeStatusFactory>();

            var customerDto = new CustomerDTO() { FirstName = "1", LastName = "2", DesiredLevel = StatusLevel.Gold };

            moqCustomeStatusFactory
                .Setup(x => x.CreateFrom(It.Is<CustomerDTO>(y => y.DesiredLevel == StatusLevel.Gold)))
                .Returns(StatusLevel.Gold);

            CustomerService customerService = new CustomerService(moqCustomeStatusFactory.Object, moqCustomerRepository.Object);

            // Act
            customerService.Create(customerDto);

            // Assert
            //moqCustomerRepository.Verify(x => x.SaveExtended(It.Is<Customer>(x => x.StatusLevel == expenctedStatusLevel)));
            moqCustomerRepository.Verify(x => x.SaveExtended(It.IsAny<Customer>()));
        }
    }
}
