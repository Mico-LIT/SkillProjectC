using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Events.Events3
{
    public delegate void EventHandler();

    public class Keyboard
    {
        public event EventHandler eventsA;
        public event EventHandler eventsB;

        public void PressKeyEventsA()
        {
            if (eventsA != null)
            {
            eventsA.Invoke();
            }
        }

        public void PressKeyEventsB()
        {
            if (eventsB != null)
            {
                eventsB.Invoke();
            }
        }

        public void Start()
        {
            while (true)
            {
                string s = Console.ReadLine();
                switch (s)
                {
                    case "a":
                    case "A":
                        PressKeyEventsA();
                        break;

                    case "B":
                    case "b":
                        PressKeyEventsB();
                        break;

                    case "exit":
                        return;
                    
                }
            }
        }
    }

    class Events_3
    {
        void MethodA()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine();
            Console.WriteLine("    X    ");
            Console.WriteLine("   X X   ");
            Console.WriteLine("  X   X  ");
            Console.WriteLine(" XXXXXXX ");
            Console.WriteLine("X       X");
            Console.ForegroundColor = ConsoleColor.White;
        }

        void MethodB()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine();
            Console.WriteLine(@"
XXXXXXXX
XX    XX
XXXXXXXX
X     XXXX 
XXXXXXXXXX
");
            Console.ForegroundColor = ConsoleColor.White;
        }

       public Events_3()
        {
            Keyboard keyboard = new Keyboard();
            keyboard.eventsA += new EventHandler(MethodA);
            keyboard.eventsB += MethodB;

            keyboard.Start();
        }
    }
}
