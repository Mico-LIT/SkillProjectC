using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.LinkedList
{
    class _002_LinkedListNode
    {
        class LinkedListNode<T>
        {
            public LinkedListNode(T value)
            {
                this.Value = value;
            }

            public T Value { get; internal set; }
            public LinkedListNode<T> Next { get; internal set; }
        }

        public _002_LinkedListNode()
        {
            var first = new LinkedListNode<string>("1");
            var second = new LinkedListNode<string>("2");

            first.Next = second;

            Console.WriteLine(first.Value);
            Console.WriteLine(first.Next.Value);

            Console.ReadLine();
        }
    }
}
