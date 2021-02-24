using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Code.Moq._001_LogingService.Interfece;
using Microsoft.Extensions.Logging;

namespace Code.Moq._001_LogingService
{
    public class LogingSevice
    {
        private readonly ILoggingConfiguration loggingConfiguration;
        private readonly IMessageBodyGenerator messageBodyGenerator;
        private readonly IMessageHeaderGenerator messageHeaderGenerator;
        private readonly ISensitiveDataScrubber sensitiveDataScrubber;

        public LogingSevice(ILoggingConfiguration loggingConfiguration, IMessageBodyGenerator messageBodyGenerator,
            IMessageHeaderGenerator messageHeaderGenerator, ISensitiveDataScrubber sensitiveDataScrubber)
        {
            this.loggingConfiguration = loggingConfiguration;
            this.messageBodyGenerator = messageBodyGenerator;
            this.messageHeaderGenerator = messageHeaderGenerator;
            this.sensitiveDataScrubber = sensitiveDataScrubber;
        }

        public void CreateEntry(string msg, LogLevel logLevel)
        {
            messageHeaderGenerator.CreateHender(logLevel);

            if (loggingConfiguration.LogStackFor(logLevel))
            {
                Console.WriteLine("Stack: ");
            }

            string clearMsg = sensitiveDataScrubber.ClearSensitive(msg);
            messageBodyGenerator.CreateBody(clearMsg);
        }
    }
}
