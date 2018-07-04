using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp.Professional.ProgrammingIO
{
    class DriveInfoExample
    {
        public DriveInfoExample()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            foreach (DriveInfo item in drives)
            {
                Console.WriteLine($"{item.Name} {item.DriveType}");
            }
            Console.ReadLine();
        }
    }
}
