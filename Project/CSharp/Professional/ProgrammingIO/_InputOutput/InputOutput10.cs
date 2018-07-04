using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp.Professional.ProgrammingIO._InputOutput
{
    class InputOutput10
    {
        public InputOutput10()
        {
            // Другой способ записи

            // var file = new FileInfo("Text.txt");
            // StreamWriter writer = file.CreateText();

            var file = new FileStream("Text.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            var writer = new StreamWriter(file, Encoding.Unicode);

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

            StreamReader reader =  File.OpenText("Text.txt");
            string input;

            while ((input = reader.ReadLine()) != null)
            {
                Console.WriteLine(input);
            }
            reader.Close();

            Console.ReadKey();
        }
    }
}
