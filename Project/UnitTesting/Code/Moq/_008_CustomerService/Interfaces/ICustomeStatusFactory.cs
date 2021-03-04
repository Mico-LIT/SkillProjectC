using Code.Moq._008_CustomerService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Moq._008_CustomerService.Interfaces
{
    public interface ICustomeStatusFactory
    {
        StatusLevel CreateFrom(CustomerDTO customer);
    }
}
