using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Moq._001_LogingService.Interfece
{
    public interface IMessageHeaderGenerator
    {
        void CreateHender(LogLevel logLevel);
    }
}
