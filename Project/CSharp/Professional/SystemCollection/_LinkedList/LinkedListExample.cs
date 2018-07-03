using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.SystemCollection._LinkedList
{
    class LinkedListExample
    {
        public LinkedListExample()
        {
            var links = new LinkedList<string>();
            LinkedListNode<string> first = links.AddFirst("First");
            LinkedListNode<string> last = links.AddLast("Last");
            LinkedListNode<string> afterlast = links.AddAfter(last, "After Last");

            LinkedListNode<string> second = links.AddBefore(last, "Second");
            links.AddAfter(second,"Third");

            foreach (var item in links)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
