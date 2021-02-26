using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Code.Moq._003_CustomerService.Interfaces;
using Code.Moq._003_CustomerService;
using Code.Moq._003_CustomerService.Classes;

namespace Code.Tests._09_Moq.CustomerServiceTests
{
    [TestClass]
    public class _003_CustomerServiceTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_NotCreated_ExeptionThrown()
        {
            // Aggregate
            var moqCustomerRepository = new Mock<ICustomerRepository>();
            var moqEmailBuilder = new Mock<IEmailBuilder>();
            var customerService = new CustomerService(moqEmailBuilder.Object, moqCustomerRepository.Object);

            var modelDTO = new CustomerDTO() { FirstName = "Viktor", LastName = "Viktor1" };

            moqEmailBuilder
                .Setup(x => x.From(It.IsAny<CustomerDTO>()))
                .Returns<string>(null);

            // тест закончится успешно если будет выбрашено исключение
            customerService.Create(modelDTO);
        }

        [TestMethod]
        public void Create_EmailCreated_CustomerShouldBeCreated()
        {
            // Aggreate
            var moqCustomerRepository = new Mock<ICustomerRepository>();
            var moqEmailBuilder = new Mock<IEmailBuilder>();
            var customerService = new CustomerService(moqEmailBuilder.Object, moqCustomerRepository.Object);

            var modelDTO = new CustomerDTO() { FirstName = "Viktor", LastName = "Viktor1" };

            moqEmailBuilder
                .Setup(x => x.From(It.IsAny<CustomerDTO>()))
                .Returns(new Address());

            // тест закончится успешно если будет выбрашено исключение
            customerService.Create(modelDTO);

            moqCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()));
        }
    }
}
