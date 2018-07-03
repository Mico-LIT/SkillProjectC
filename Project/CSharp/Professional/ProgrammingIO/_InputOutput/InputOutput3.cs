using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp.Professional.ProgrammingIO._InputOutput
{
    class InputOutput3
    {
        public InputOutput3()
        {
            var directory = new DirectoryInfo(@"D:\TESTDIR");

            if (directory.Exists)
            {
                directory.CreateSubdirectory("SubDir");
                directory.CreateSubdirectory(@"MyDir\SubMyDir");
                Console.WriteLine("Директории созданы");
            }
            else
            {
                Console.WriteLine("Увы не сущевствует директория");
            }

            Console.ReadLine();
        }
    }
}
