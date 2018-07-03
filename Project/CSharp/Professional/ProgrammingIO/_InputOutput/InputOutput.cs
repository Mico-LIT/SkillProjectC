using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp.Professional.ProgrammingIO._InputOutput
{
    class InputOutput
    {
        public InputOutput()
        {
            var directory = new DirectoryInfo(@"C:\Windows\assembly");

            if (directory.Exists)
            {
                Console.WriteLine($"{directory.FullName}");             // Полное имя директории 
                Console.WriteLine($"{directory.Name}");                 // Имя директории  ..
                Console.WriteLine($"{directory.Parent}");               // Родитеьская директория
                Console.WriteLine($"{directory.CreationTime}");         // Время создания директории
                Console.WriteLine($"{directory.Attributes.ToString()}"); // Аттрибуты
                Console.WriteLine($"{directory.Root}");                 // Корневой диск
                Console.WriteLine($"{directory.LastAccessTime}");       // Последнее время доступа
                Console.WriteLine($"{directory.LastWriteTime}");        // Время последнего изменения 
            }
            else
            {
                Console.WriteLine("Увы не сущевствует директория");
            }

            Console.ReadLine();
        }
    }
}
