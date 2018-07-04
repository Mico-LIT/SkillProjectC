using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp.Professional.ProgrammingIO
{
    class FileInfoExample
    {
        public FileInfoExample()
        {
            var file = new FileInfo(@"C:\Windows\notepad.exe");
            try
            {
                file.CopyTo(@"D:\aaa.exe");
                Console.WriteLine("Копирование успешно");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            Console.ReadLine();
        }
    }
}
