using Code.Moq._004_CustomerService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Moq._004_CustomerService.Interfaces
{
    public interface IIdFactory
    {
        Guid Create();
    }
}
