using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Moq._011_CustomerService.Interfaces
{
    public interface IWorkSettings
    {
        int? WorkId { get; set; }
        string WorkspaceName { get; set; }
    }
}
