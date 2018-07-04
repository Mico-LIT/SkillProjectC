using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp.Professional.ProgrammingIO._InputOutput
{
    class InputOutput9
    {
        public InputOutput9()
        {
            var file = new FileInfo("Text.txt");
            StreamWriter writer = file.CreateText();

            writer.WriteLine("Привет)");
            writer.WriteLine("Привет2)");

            writer.Write(writer.NewLine);

            writer.WriteLine("привет3)");

            for (int i = 0; i < 10; i++)
            {
                writer.Write(i + " ");
            }
            writer.WriteLine();

            writer.Close();

            Console.ReadKey();
        }
    }
}
