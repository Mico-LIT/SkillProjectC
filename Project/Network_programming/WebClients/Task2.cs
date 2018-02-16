using Microsoft.Win32;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Network_programming.WebClients
{
   public static class Task2
    {
       public static void Start()
        {
            WebClient web = new WebClient();
            using (Stream steam = web.OpenRead("https://vk.com/"))
            {
                string str = "";
                using (StreamReader sr = new StreamReader(steam))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        str += s;
                    }
                }
                Console.WriteLine(str);
                File.WriteAllText("Vk.html", str);
            }
            Console.WriteLine("OK");
            
        }
    }
}
