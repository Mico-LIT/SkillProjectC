using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.ProgrammingIO
{
    class PathExample
    {
        public PathExample()
        {
            string path = @"C:\Windows\notepad.exe";

            Console.WriteLine(path);

            Console.WriteLine(Path.GetExtension(path));
            Console.WriteLine(Path.ChangeExtension(path, "bat"));

            Console.WriteLine(path);

            Console.ReadLine();
        }
    }
}
