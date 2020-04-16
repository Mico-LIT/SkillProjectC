using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Operators
{
    public class Operators2
    {
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        public static extern int MessageBox(IntPtr h, string m, string c, int type);

        public Operators2()
        {
            string myString;
            Console.Write("Enter your message: ");
            myString = Console.ReadLine();
            MessageBox((IntPtr)0, myString, "My Message Box", 0);
        }
    }
}
