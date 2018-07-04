using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp.Professional.ProgrammingIO._InputOutput
{
    class InputOutput8
    {
        public InputOutput8()
        {
            // Создаем объект класса MemoryStream
            var memory = new MemoryStream();

            // Задаем требуемый объем памяти
            memory.Capacity = 256;

            for (int i = 0; i < 256; i++)
            {
                memory.WriteByte((byte)i);
            }

            // Переставляем внутренний указательна начало
            memory.Position = 0;

            // считываем байты из потока
            for (int i = 0; i < 256; i++)
            {
                Console.WriteLine(" "+ memory.ReadByte());
            }

            Console.WriteLine(new string('_',5));

            // Сохраняем данные из MemoryStream в массив байт
            byte[] arr = memory.ToArray();

            foreach (var item in arr)
            {
                Console.Write(item);
            }

            Console.WriteLine(new string('_', 10));

            FileStream filestream = new FileStream("Dump.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            memory.WriteTo(filestream);
            filestream.Position = 0;

            for (int i = 0; i < 256; i++)
            {
                Console.WriteLine(filestream.ReadByte());
            }

            filestream.Close();
            memory.Close();


            Console.ReadKey();
        }
    }
}
