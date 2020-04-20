using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.LinkedList
{
    class _005_LinkedList
    {
        public _005_LinkedList()
        {
            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddFirst(1);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddFirst(4);

            linkedList.Contains(2);

            var result = linkedList.Find(1);
            var next = result.Next;
            var previous = result.Previous;
        }
    }
}
