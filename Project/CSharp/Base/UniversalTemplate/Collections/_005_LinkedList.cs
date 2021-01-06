using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.Collections
{
    class _005_LinkedList
    {
        public _005_LinkedList()
        {
            LinkedList<int> vs = new LinkedList<int>();

            vs.AddFirst(1);
            vs.AddFirst(2);
            var first = vs.First;

            vs.AddBefore(first, 4);
            vs.AddAfter(first, 3);

            var node = vs.First;

            while (node !=null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }
    }
}
