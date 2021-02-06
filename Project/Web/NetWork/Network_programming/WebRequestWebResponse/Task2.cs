using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Network_programming.WebRequestWebResponse
{
    class Task2
    {
        public static async void Start()
        {
            WebRequest wrq = WebRequest.Create("www.vk.com");
            WebResponse wrp = await wrq.GetResponseAsync();
            using (Stream stream = wrp.GetResponseStream())
            {
                using (StreamReader str = new StreamReader(stream))
                {
                    Console.WriteLine(str.ReadLine());
                }
            }
        }
    }
}
