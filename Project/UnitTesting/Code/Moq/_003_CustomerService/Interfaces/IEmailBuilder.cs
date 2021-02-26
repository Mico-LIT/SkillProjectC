using Code.Moq._003_CustomerService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Moq._003_CustomerService.Interfaces
{
    public interface IEmailBuilder
    {
        Address From(CustomerDTO customerDTO);
    }
}
