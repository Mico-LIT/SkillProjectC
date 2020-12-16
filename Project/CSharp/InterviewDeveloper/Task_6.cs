using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.InterviewDeveloper
{
    class Task_6
    {
        private static Object syncObject = new Object();
        private static void Write()
        {
            lock (syncObject)
            {
                Console.WriteLine("test");
            }
        }
        public void Main()
        {
            lock (syncObject)
            {
                Write();
            }
        }
    }
}
