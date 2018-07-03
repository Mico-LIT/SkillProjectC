using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp.Professional.ProgrammingIO._InputOutput
{
    class InputOutput4
    {
        public InputOutput4()
        {
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Диски:");
            foreach (var item in drives)
            {
                Console.WriteLine(item);
            }

            var directory = new DirectoryInfo(@"D:\TESTDIR");

            Console.WriteLine("Удаляем Директории. нажми  Enter");
            Console.ReadLine();

            try
            {
                Directory.Delete(@"D:\TESTDIR\subdir");
                Directory.Delete(@"D:\TESTDIR\mydir",true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            Console.ReadLine();
        }
    }
}
