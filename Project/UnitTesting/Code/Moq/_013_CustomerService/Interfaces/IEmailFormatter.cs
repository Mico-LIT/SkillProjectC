using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Moq._013_CustomerService.Interfaces
{
    public interface IEmailFormatter
    {
        void CreateMessage(string email);
    }
}
