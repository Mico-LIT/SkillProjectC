using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_programming.WebClients
{
   public static class Task
    {
        public static void Start()
        {
            WebClient wc = new WebClient();
            wc.DownloadFile("https://celestrak.com/NORAD/elements/weather.txt","wea.txt");
            Console.WriteLine("ок");
        }
    }
}
