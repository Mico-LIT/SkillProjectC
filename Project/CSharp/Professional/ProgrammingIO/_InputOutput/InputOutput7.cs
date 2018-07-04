using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp.Professional.ProgrammingIO._InputOutput
{
    class InputOutput7
    {
        public InputOutput7()
        {
            var stream = new FileStream("Test.bat", FileMode.OpenOrCreate, FileAccess.ReadWrite);

            //записываем байты в файл
            for (int i = 0; i < 256; i++)
            {
                stream.WriteByte((byte)i);
            }

            Console.WriteLine(stream.Position);
            // Переставляем внутренний указательна на начало
            stream.Position = 0;

            for (int i = 0; i < 256; i++)
            {
                Console.Write(new string('_',5)+" "+ stream.ReadByte()  );
                Console.WriteLine(" "+stream.Position);
            }

            // закрываем FileStream
            stream.Close();

            Console.ReadKey();
        }
    }
}
