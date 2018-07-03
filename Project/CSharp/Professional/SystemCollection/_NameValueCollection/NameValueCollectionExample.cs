using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.SystemCollection._NameValueCollection
{
    class NameValueCollectionExample
    {
        public NameValueCollectionExample()
        {
            var nvc = new NameValueCollection
            {
                {"key","Some Text" },
                {"Key","More Text" }
            };


            foreach (var item in nvc.GetValues("Key"))
            {
                Console.WriteLine(item);
            }

            // Использование индексаторов отличается от использования метода Add()
            // Индексатор не добавляет новое значение, а заменяет сущевствующее

            nvc["First"] = "1st";
            nvc["First"] = "First";

            Console.WriteLine(nvc.GetValues("First").Length); //1

            foreach (var item in nvc.GetValues("First"))
            {
                Console.WriteLine(item);
            }

            // Add Добавляет новое значение
            nvc.Add("Second", "2nd");
            nvc.Add("Second", "SECOND");
            Console.WriteLine(nvc.GetValues("Second").Length); //2

            foreach (var item in nvc.GetValues("Second"))
            {
                Console.WriteLine(item);
            }
            //------------------------------------------------------------------------
            Console.WriteLine("App.Config appSettings values");

            var appsettings = ConfigurationManager.AppSettings;

            foreach (string item in appsettings)
            {
                Console.WriteLine($"{item} {appsettings[item]}");
            }

            Console.ReadLine();
        }
    }
}
