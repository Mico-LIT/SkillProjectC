using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp.Professional.ProgrammingIO._InputOutput
{
    class InputOutput2
    {
        public InputOutput2()
        {
            var directory = new DirectoryInfo(@".");

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

                Console.WriteLine();
                FileInfo[] file = directory.GetFiles();
                Console.WriteLine($"Найдено {file.Length} файлов");
                Console.WriteLine();
                foreach (var item in file)
                {
                    Console.WriteLine($"{item.Name}");
                    Console.WriteLine($"{item.Length}");
                    Console.WriteLine($"{item.CreationTime}");
                    Console.WriteLine($"{item.Attributes.ToString()}");
                    Console.WriteLine();
                }


            }
            else
            {
                Console.WriteLine("Увы не сущевствует директория");
            }





            Console.ReadLine();
        }
    }
}
