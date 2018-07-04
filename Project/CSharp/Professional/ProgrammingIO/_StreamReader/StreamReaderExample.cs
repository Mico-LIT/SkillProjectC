using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.ProgrammingIO._StreamReader
{
    class StreamReaderExample
    {
        public StreamReaderExample()
        {
            // считывание 
            StreamReader reader = File.OpenText(@"D:\test.txt");

            while (!reader.EndOfStream)
            {
                string str = reader.ReadLine();

                if (str !=null && str.Contains("Andrew"))
                {
                    Console.WriteLine("Found :" + str);
                    break;
                }
            }
            reader.Close();
        }

        public void StreamReaderExample1()
        {
            //Создание файла 
            FileStream file = File.Create(@"test.txt");

            //1
            var writer = new StreamWriter(file);
            writer.WriteLine("hi");
            writer.Close();

            //2
            writer = File.CreateText("test.txt");
            writer.WriteLine("Hello");
            writer.Close();

            //3
            File.WriteAllText(@"test.txt", "Hi23");

            //4
            file = null;
            file = File.Open(@"test.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
            file.Close();

            //5
            file = File.OpenWrite(@"text.txt");
            //file.Close();

            //6 исключение так как файл занят
            file = File.Open(@"text.txt", FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
            file.Close();
            // file.Close();

        }
        public void StreamReaderExample2()
        {
            //Создание файла 
            FileStream file = File.Create(@"test.txt");

            BufferedStream buffered = new BufferedStream(file);

            StreamWriter write = new StreamWriter(buffered);

            write.WriteLine("Ho Ho");

            buffered.Position = 0;
            write.Close();

            Console.ReadKey();
        }
    }
}
