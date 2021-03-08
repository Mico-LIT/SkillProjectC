using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Code.Moq._010_CustomerService.Classes;
using Code.Moq._010_CustomerService.Interfaces;
using Code.Moq._010_CustomerService;

namespace Code.Tests._09_Moq.CustomerServiceTests
{
    /// <summary>
    /// MockingProperty
    /// </summary>
    [TestClass]
    public class _010_CustomerServiceTest
    {
        [TestMethod]
        public void Create_ShouldSetTimeZone_CallSave()
        {
            // Aggregate
            var moqCustomerRepository = new Mock<ICustomerRepository>();
            var moqWorkSettings = new Mock<IWorkSettings>();

            moqWorkSettings.Setup(x => x.WorkId).Returns(12);

            CustomerService customerService = new CustomerService(moqWorkSettings.Object, moqCustomerRepository.Object);

            // Act
            customerService.Create(new CustomerDTO());

            moqCustomerRepository.VerifySet(x => x.LolacTimeZone = It.IsAny<string>());
            moqCustomerRepository.Verify(x => x.Save(It.IsAny<Customer>()));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Create_ShouldSetWorkId_ArgumentNullException()
        {
            // Aggregate
            var moqCustomerRepository = new Mock<ICustomerRepository>();
            var moqWorkSettings = new Mock<IWorkSettings>();

            moqWorkSettings.Setup(x => x.WorkId).Returns((int?)null);

            CustomerService customerService = new CustomerService(moqWorkSettings.Object, moqCustomerRepository.Object);

            // Act
            customerService.Create(new CustomerDTO());
        }
    }
}
