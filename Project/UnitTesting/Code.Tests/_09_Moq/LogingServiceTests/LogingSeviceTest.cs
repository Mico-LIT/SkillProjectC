using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Code.Moq._001_LogingService.Interfece;
using Code.Moq._001_LogingService;
using Microsoft.Extensions.Logging;

namespace Code.Tests._09_Moq.LogingServiceTests
{
    [TestClass]
    public class LogingSeviceTest
    {
        LogingSevice logingSevice;

        private Mock<ILoggingConfiguration> mockLoggingConfig;
        private Mock<IMessageBodyGenerator> mockMessageBodyGenerator;
        private Mock<IMessageHeaderGenerator> mockMessageHeaderGenerator;
        private Mock<ISensitiveDataScrubber> mockSensitiveDataScrubber;

        [TestInitialize]
        public void Init()
        {
            mockLoggingConfig = new Mock<ILoggingConfiguration>();
            mockMessageBodyGenerator = new Mock<IMessageBodyGenerator>();
            mockMessageHeaderGenerator = new Mock<IMessageHeaderGenerator>();
            mockSensitiveDataScrubber = new Mock<ISensitiveDataScrubber>();

            //mockLoggingConfig.Object - объект заглушка с интерфесом зависимости
            logingSevice = new LogingSevice(mockLoggingConfig.Object, mockMessageBodyGenerator.Object,
                mockMessageHeaderGenerator.Object, mockSensitiveDataScrubber.Object);
        }

        [TestMethod]
        public void Logger_CreateEntry_SensitiveDataShouldBeScrubber()
        {
            // Arrang
            // Setup - устанавливаем параметры которые определяют правильность работы тестируемого метода
            // Ожидаем вызова метода ClearSensitive
            mockSensitiveDataScrubber.Setup(x => x.ClearSensitive(It.IsAny<string>()));

            // Act
            logingSevice.CreateEntry("test", LogLevel.Trace);

            // Assert
            //VerifyAll - проверяет правильно ли взаимодействовал тестиремый метод
            mockSensitiveDataScrubber.VerifyAll();
        }

        [TestMethod]
        public void Logger_CreateEntry_CreateHender()
        {
            mockMessageHeaderGenerator.Setup(x => x.CreateHender(It.IsAny<LogLevel>()));
            logingSevice.CreateEntry("test", LogLevel.Information);
            mockMessageHeaderGenerator.VerifyAll();
        }

        [TestMethod]
        public void Logger_CreateEntry_CreateBody()
        {
            mockMessageBodyGenerator.Setup(x => x.CreateBody(It.IsAny<string>()));
            logingSevice.CreateEntry("test", LogLevel.Information);
            mockMessageBodyGenerator.VerifyAll();
        }
    }
}
