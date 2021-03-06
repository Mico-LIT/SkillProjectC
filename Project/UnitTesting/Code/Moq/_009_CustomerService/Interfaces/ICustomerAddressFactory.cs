using Code.Moq._009_CustomerService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Moq._009_CustomerService.Interfaces
{
    public interface ICustomerAddressFactory
    {
        Address CreateFrom(CustomerDTO customer);
    }
}
