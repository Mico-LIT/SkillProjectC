using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace CSharp.Professional.Serealizations.XML
{
    class Go
    {
        readonly XmlSerializer serializer = new XmlSerializer(typeof(MyClassData));
        MyClassData instance1 = new MyClassData();
        MyClassData instance2;

        public Go()
        {
            _Serialize();
            _Deserialize();
        }

        private void _Deserialize()
        {
            FileStream stream = new FileStream("Test.xml",FileMode.Open,FileAccess.Read);
            instance2 = serializer.Deserialize(stream) as MyClassData;
            stream.Close();
            Console.WriteLine($"{instance2.I}  {instance2.Str}");

            foreach (var item in instance2.MyList)
            {
                Console.WriteLine($"{item}");
            }

            Console.ReadLine();
        }

        void _Serialize(){

            for (int i = 0; i < 10; i++)
            {
                instance1.MyList.Add("Element: " + i);
            }

            FileStream fileStream = new FileStream("Test.xml", FileMode.Create, FileAccess.Write);
            serializer.Serialize(fileStream, instance1);
            Console.WriteLine("Serealization xml");
            fileStream.Close();
            Console.ReadLine();

        }
    }
}
