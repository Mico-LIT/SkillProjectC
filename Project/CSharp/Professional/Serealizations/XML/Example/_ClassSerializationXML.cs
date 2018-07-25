using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

/// <summary>
///  Что бы создать класс, который можно сериализовать в XML, нужно выполнить следующее:
/// - Объявиь класс как открытый (Public)
/// - Объявить все члены, которые нужно сериализовать, как открытые (Public)
/// - Создать конструктор по умолчанию (Без параметров)
/// </summary>

namespace CSharp.Professional.Serealizations.XML.Example
{
    //[XmlRoot("CarItem")]
    class ShopCar
    {
        //[XmlAttribute]
        public int ID;
        public decimal price;
        //[XmlIgnore]
        public decimal total;
        public int quantity;
    }

    class _ClassSerializationXML
    {
        public _ClassSerializationXML()
        {
            var item = new ShopCar() { ID = 12341, price = 1400, quantity = 2 };
            item.total = item.price * item.quantity;

            // Создаем файл для сохранения
            FileStream stream = new FileStream("_ClassSerializationXML.xml", FileMode.Create);

            // Создаем объект
            XmlSerializer serial = new XmlSerializer(typeof(_ClassSerializationXML));
            
            //Сериализуем
            serial.Serialize(stream, item);
            stream.Close();
        }
    }
}
