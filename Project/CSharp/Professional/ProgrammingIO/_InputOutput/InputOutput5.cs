using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp.Professional.ProgrammingIO._InputOutput
{
    class InputOutput5
    {
        public InputOutput5()
        {
            FileInfo file = new FileInfo(@".\Test.txt");
            FileStream stream = file.Create();

            // Инфо по файлу
            Console.WriteLine($"{file.FullName}");
            Console.WriteLine($"{file.Attributes.ToString()}");
            Console.WriteLine($"{file.CreationTime}");
            Console.WriteLine("Нажмите на любую клавишу для удаления");
            Console.ReadKey();

            stream.Close();

            file.Delete();

            Console.ReadKey();
        }
    }
}
