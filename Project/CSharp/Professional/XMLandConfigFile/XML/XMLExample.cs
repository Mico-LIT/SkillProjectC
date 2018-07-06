using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.XPath;

namespace CSharp.Professional.XMLandConfigFile.XML
{
    class XMLExample
    {
        public XMLExample()
        {
        }

        public void XMLExample1()
        {
            var document = new XmlDocument();
            document.Load("XMLFile1.xml");

            Console.WriteLine(document.InnerText);
            Console.WriteLine(new string('-', 20));
            Console.WriteLine(document.InnerXml);

            Console.ReadLine();
        }

        public void XMLExample2()
        {
            FileStream stream = new FileStream("XMLFile1.xml",FileMode.Open);
            XmlTextReader reader = new XmlTextReader(stream);

            while (reader.Read())
            {
                Console.WriteLine("{0,-15}{1,-15}{2,-15}",
                    reader.NodeType,
                    reader.Name,
                    reader.Value);
            }

            reader.Close();
            stream.Close();

            Console.ReadLine();
        }

        public void XMLExample3()
        {
            var document = new XmlDocument();
            document.Load("XMLFile1.xml");

            XmlNode root = document.DocumentElement;

            foreach (XmlNode items in root.ChildNodes)
            {
                Console.WriteLine("Found:");
                foreach (XmlNode item in items.ChildNodes)
                {
                    Console.WriteLine(item.Name +" "+ item.InnerText);
                }
                Console.WriteLine(new string('-',40));
            }

            Console.ReadLine();
        }

        public void XMLExample4()
        {
            var reader = new XmlTextReader("XMLFile1.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.Name.Equals("Title"))
                    {
                        Console.WriteLine(reader.GetAttribute("FontSize"));
                    }
                }
            }

            Console.ReadLine();
        }

        public void XMLExample5()
        {
            var reader = new XmlTextReader("XMLFile1.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    if (reader.HasAttributes)
                    {
                        while (reader.MoveToNextAttribute())
                        {
                            Console.WriteLine($"{reader.Name} = {reader.Value}");
                        }
                        Console.WriteLine(reader.GetAttribute("FontSize"));
                    }
                }
            }

            Console.ReadLine();
        }

        public void XMLExample6()
        {
            var doc = new XPathDocument("XMLFile1.xml");
            XPathNavigator navigator = doc.CreateNavigator();

            XPathNodeIterator iterator1 = navigator.Select("ListOfBooks/Book/Title");

            foreach (var item in iterator1)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(new string('-', 30));

            XPathExpression expr = navigator.Compile("ListOfBooks/Book[2]/Title");
            XPathNodeIterator iterator2 = navigator.Select(expr);

            foreach (var item in iterator2)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
