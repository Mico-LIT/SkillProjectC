using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Moq._007_CustomerService.Interfaces
{
    public interface ICustomerRepository
    {
        void Save(Classes.Customer custumer);
    }
}
