using Code.Moq._012_CustomerService.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Moq._012_CustomerService.Interfaces
{
    public interface ICustomerRepository
    {
        void Save(Classes.Customer custumer);
        string LolacTimeZone { get; set; }
        event EventHandler<NotifiEventArg> Notify;
    }
}
