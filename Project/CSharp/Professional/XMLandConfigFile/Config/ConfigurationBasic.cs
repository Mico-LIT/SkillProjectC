using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections.Specialized;
using System.Collections;

namespace CSharp.Professional.XMLandConfigFile.Config
{
    class ConfigurationBasic
    {
        public void ConfigurationBasic1()
        {
            //1 Устарел
            //string value = ConfigurationSettings.AppSettings["Foo"];

            string value = ConfigurationManager.AppSettings["Foo"];
            Console.WriteLine(value);
            Console.WriteLine(new string('-',20));

            //2
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            Console.WriteLine(appSettings["Foo"]);
            Console.WriteLine(appSettings[0]);

            Console.WriteLine(new string('-', 20));

            foreach (var item in appSettings)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }

        public void ConfigurationBasic2()
        {
            NameValueCollection appSettings = ConfigurationManager.AppSettings;
            Int32 count = 0;
            IEnumerator sett = appSettings.Keys.GetEnumerator();

            while (sett.MoveNext())
            {
                Console.WriteLine($"{appSettings.Keys[count]}  {appSettings[count]}");
                count++;
            }

            Console.ReadLine();
        }
    }
}
