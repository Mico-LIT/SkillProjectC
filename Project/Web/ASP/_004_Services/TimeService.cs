using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _004_Services
{
    public interface ITimeService { string GetTime(); }

    public class TimeServiceFull : ITimeService
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("hh:mm:ss");
        }
    }

    public class TimeServiceHoursMinutes : ITimeService
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("hh:mm");
        }
    }

    public class TimeServiceHours : ITimeService
    {
        public string GetTime()
        {
            return DateTime.Now.ToString("hh");
        }
    }


}
