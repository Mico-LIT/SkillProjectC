using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.LinkedList
{
    class _001_Singly_List
    {
        class Node
        {
            public int Value { get; set; }
            public Node Next { get; set; }
        }

        void Display(Node node)
        {
            while (node != null)
            {
                Console.WriteLine(node.Value);
                node = node.Next;
            }
        }

        public _001_Singly_List()
        {
            var firstNode = new Node() { Value = 1 };
            var middleNode = new Node() { Value = 2 };

            firstNode.Next = middleNode;

            var lastNode = new Node() { Value = 7 };

            middleNode.Next = lastNode;
            Display(firstNode);

            Console.ReadLine();
        }
    }
}
