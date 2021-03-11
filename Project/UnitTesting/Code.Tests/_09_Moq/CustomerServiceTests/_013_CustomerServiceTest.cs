using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Code.Moq._013_CustomerService.Classes;
using Code.Moq._013_CustomerService.Interfaces;
using Code.Moq._013_CustomerService;

namespace Code.Tests._09_Moq.CustomerServiceTests
{
    /// <summary>
    /// Simple Mock Verification
    /// </summary>
    [TestClass]
    public class _013_CustomerServiceTest
    {
        [TestMethod]
        public void Create_Strict()
        {
            // arrange
            var customerDTOs = new List<CustomerDTO>
            {
                new CustomerDTO { FirstName="1", LastName="1" },
                new CustomerDTO { FirstName="2", LastName="2" },
                new CustomerDTO { FirstName="3", LastName="3" },
            };

            // MockBehavior.Strict будет выбрасовать икслючение при вызове метода
            // для которого явно не устанавливались начтройки через Setup
            var mockCustomerRepository = new Mock<ICustomerRepository>(MockBehavior.Strict);
            var mockEmailFormatter = new Mock<IEmailFormatter>(MockBehavior.Strict);

            mockCustomerRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            mockEmailFormatter.Setup(x => x.CreateMessage(It.IsAny<string>()));

            var customerService = new CustomerService(mockEmailFormatter.Object, mockCustomerRepository.Object);

            // act
            customerService.Create(customerDTOs);

            // assert
            mockCustomerRepository.Verify();
            mockEmailFormatter.Verify();
        }

        [TestMethod]
        public void Create_Loose()
        {
            // arrange
            var customerDTOs = new List<CustomerDTO>
            {
                new CustomerDTO { FirstName="1", LastName="1" },
                new CustomerDTO { FirstName="2", LastName="2" },
                new CustomerDTO { FirstName="3", LastName="3" },
            };

            // Moq.MockBehavior.Loose = Default values

            // MockBehavior.Loose будет возвращатся значнеие по умолчанию
            // не требут предворительной настройки через Setup

            var mockCustomerRepository = new Mock<ICustomerRepository>(MockBehavior.Loose);
            var mockEmailFormatter = new Mock<IEmailFormatter>(MockBehavior.Loose);

            var customerService = new CustomerService(mockEmailFormatter.Object, mockCustomerRepository.Object);

            // act
            customerService.Create(customerDTOs);

            // assert
            mockCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()), Times.Exactly(3));
        }

        [TestMethod]
        public void Create_Factory()
        {
            // arrange
            var customerDTOs = new List<CustomerDTO>
            {
                new CustomerDTO { FirstName="1", LastName="1" },
                new CustomerDTO { FirstName="2", LastName="2" },
                new CustomerDTO { FirstName="3", LastName="3" },
            };

            // фабрика
            MockRepository mockRepository = new MockRepository(MockBehavior.Loose);

            // создаем через фабрику
            var mockCustomerRepository = mockRepository.Create<ICustomerRepository>();
            var mockEmailFormatter = mockRepository.Create<IEmailFormatter>();

            mockCustomerRepository.Setup(x => x.Save(It.IsAny<Customer>()));
            mockEmailFormatter.Setup(x => x.CreateMessage(It.IsAny<string>()));

            var customerService = new CustomerService(mockEmailFormatter.Object, mockCustomerRepository.Object);

            // act
            customerService.Create(customerDTOs);

            // assert
            // Проверка всех mock объектов
            mockRepository.Verify();
        }
    }
}
