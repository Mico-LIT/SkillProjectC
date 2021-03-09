using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Code.Moq._011_CustomerService.Classes;
using Code.Moq._011_CustomerService.Interfaces;
using Code.Moq._011_CustomerService;

namespace Code.Tests._09_Moq.CustomerServiceTests
{
    /// <summary>
    /// Mock StubbingProperties
    /// </summary>
    [TestClass]
    public class _011_CustomerServiceTest
    {
        [TestMethod]
        public void Create_SaveMethodCustomer_Simple1()
        {
            // Aggregate
            var moqCustomerRepository = new Mock<ICustomerRepository>();
            var moqWorkSettings = new Mock<IWorkSettings>();

            // вариант 1
            moqWorkSettings.SetupProperty(x => x.WorkId, 12);
            moqWorkSettings.SetupProperty(x => x.WorkspaceName, "Test");

            // Возможность изменить значение свойства
            moqWorkSettings.Object.WorkspaceName = "22 Tets";

            CustomerService customerService = new CustomerService(moqWorkSettings.Object, moqCustomerRepository.Object);
            customerService.Create(new CustomerDTO());

            moqCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()));
        }

        [TestMethod]
        public void Create_SaveMethodCustomer_Simple2()
        {
            // Aggregate
            var moqCustomerRepository = new Mock<ICustomerRepository>();
            var moqWorkSettings = new Mock<IWorkSettings>();

            // вариант 2
            moqWorkSettings.SetupAllProperties();
            moqWorkSettings.Object.WorkId = 3333;
            moqWorkSettings.Object.WorkspaceName = "4444";

            CustomerService customerService = new CustomerService(moqWorkSettings.Object, moqCustomerRepository.Object);
            customerService.Create(new CustomerDTO());

            // assert
            moqCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()));
        }
    }
}
