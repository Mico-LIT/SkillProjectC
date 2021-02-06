using System.IO;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network_programming.WebRequestWebResponse
{
    public class Task1
    {
        public static void start()
        {
            WebRequest wrq = WebRequest.Create("https://vk.com/");
            WebResponse wrp = wrq.GetResponse();
            using (Stream stream = wrp.GetResponseStream())
            {
                using (StreamReader st = new StreamReader(stream))
                {
                    string str = "";
                    do
                    {
                        str = st.ReadLine();
                        Console.WriteLine(str);
                    } while (str != null);
                }
            }
        }

        /// <summary>
        /// HttpWebRequest
        /// HttpWebResponse
        /// </summary>
        public static async void Start2()
        {
            HttpWebRequest wrq = (HttpWebRequest)WebRequest.Create("https://vk.com");
            HttpWebResponse http = (HttpWebResponse)await wrq.GetResponseAsync();

            using (Stream stream = http.GetResponseStream())
            {
                using (StreamReader str = new StreamReader(stream))
                {
                    Console.WriteLine(str.ReadLine());
                }
            }
        }

        public static void Start3()
        {
            HttpWebRequest http = WebRequest.Create("https://vk.com") as HttpWebRequest;
            HttpWebResponse res = http.GetResponse() as HttpWebResponse;
            for (int i = 0; i < res.Headers.Count; i++)
            {
                Console.WriteLine("{0}: {1}", res.Headers.GetKey(i), res.Headers[i]);
            }
        }

    }
}
