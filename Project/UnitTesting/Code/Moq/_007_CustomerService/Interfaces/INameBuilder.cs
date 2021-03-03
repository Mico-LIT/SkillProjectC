using Code.Moq._007_CustomerService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Moq._007_CustomerService.Interfaces
{
    public interface INameBuilder
    {
        string From(string firstName, string lastName);
    }
}
