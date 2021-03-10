using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Code.Moq._012_CustomerService.Classes;
using Code.Moq._012_CustomerService.Interfaces;
using Code.Moq._012_CustomerService;

namespace Code.Tests._09_Moq.CustomerServiceTests
{
    /// <summary>
    /// EventMocking
    /// </summary>
    [TestClass]
    public class _012_CustomerServiceTest
    {
        [TestMethod]
        public void Create_NotifyEventRised()
        {
            // Aggregate
            var moqCustomerRepository = new Mock<ICustomerRepository>();
            var moqMalingRepository = new Mock<IMalingRepository>();
            CustomerService customerService = new CustomerService(moqMalingRepository.Object, moqCustomerRepository.Object);

            // Raise инициирует событие Notify и передает параметры
            moqCustomerRepository.Raise(x => x.Notify += null, new NotifiEventArg() { CustomerName = "test" });

            moqMalingRepository.Verify(x => x.CreateNewMessage(It.IsAny<string>()));
        }
    }
}
