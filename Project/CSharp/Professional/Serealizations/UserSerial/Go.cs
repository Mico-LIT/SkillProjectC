using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace CSharp.Professional.Serealizations.UserSerial
{
    class Go
    {
        public Go()
        {
            Car car = new Car("Mersedes-Benz", 250);
            Stream stream = File.Create("CarDate.dat");

            BinaryFormatter formatter = new BinaryFormatter();

            // сереализация (Вызов метода ISerializable.GetObjectData()).
            formatter.Serialize(stream, car);
            stream.Close();

            stream = File.OpenRead("CarDate.dat");

            // Десериализация (Вызов спецконструктора).
            car = formatter.Deserialize(stream) as Car;

            Console.WriteLine($"{car.Name} \n  {car.Speed}");

            stream.Close();

            Console.ReadLine();
        }
    }
}
