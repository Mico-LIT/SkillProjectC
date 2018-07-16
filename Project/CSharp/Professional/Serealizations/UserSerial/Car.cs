using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CSharp.Professional.Serealizations.UserSerial
{
    [Serializable]
    class Car : ISerializable
    {
        private string name;
        private int speed;

        public int Speed { get { return speed; } set { speed = value; } }
        public string Name { get { return name; } set { name = value; } }

        public Car(string name, int speed)
        {
            this.name = name;
            this.speed = speed;
        }

        /// <summary>
        /// Специальный вариант конструктора.
        /// </summary>
        /// SerializationInfo - объект в который помещаем все пары имя-значение представляющие состояние
        /// SerializationInfo - мешок со свойствами
        /// СПЕЦИАЛЬНЫЙ КОНСТРУКТОР ДЛЯ ДЕСЕРЕАЛИЗАЦИИ
        /// Можно прикрутить Шифрование
        private Car(SerializationInfo PropertyBag, StreamingContext context)
        {
            Console.WriteLine("[ctor] ContextState:{0}",context.State.ToString());

            // из мешка со свойствами извлекаем значение свойств помещенных ранее в метод GetObjectData
            name = PropertyBag.GetString("name");
            speed = PropertyBag.GetInt32("speed");
        }

        /// Можно прикрутить Шифрование
        /// Используется для пользовательской сереализации
        void ISerializable.GetObjectData(SerializationInfo PropertyBag, StreamingContext context)
        {
            // Значение All перечисления StreamingContext свойство context.State, указывает,
            // что данные могут быть переданы в любое место или получены из любова места 
            Console.WriteLine("[GetObjectData] ContextState: {0}",context.State.ToString());

            // В мешок со свойствами добавляем два свойства и соответственно
            PropertyBag.AddValue("name",name);
            PropertyBag.AddValue("speed", speed);
        }
    }
}
