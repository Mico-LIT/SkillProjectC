using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.Serealizations.Binary
{
    class Go
    {
        public Go()
        {
            Mersedes auto = new Mersedes("CLK 500", 250, Mode.Lux);
            auto.OnRadio(true);
            auto.ShowMode();

            FileStream fileStream = File.Create("CarData.dat");
            
            // Помещаем объектный граф (для базовых типов) в поток в двоичном формате.
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            //Сереализация
            binaryFormatter.Serialize(fileStream, auto);

            fileStream.Close();

            fileStream = File.OpenRead("CarData.dat");

            // Десереализация
            auto = binaryFormatter.Deserialize(fileStream) as Mersedes;

            Console.WriteLine($"{auto.Name}");
            Console.WriteLine($"{auto.Speed}");
            fileStream.Close();

            Console.ReadLine();

        }

    }
}
