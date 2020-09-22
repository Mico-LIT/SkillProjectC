using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.Trees
{
    /// <summary>
    /// Кости TreeNode
    /// </summary>
    class _001_TreeNode
    {
        public class BineryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
        {
            public BineryTreeNode<TNode> Left { get; set; }
            public BineryTreeNode<TNode> Rigth { get; set; }

            public TNode Value { get; private set; }

            public BineryTreeNode(TNode value)
            {
                Value = value;
            }

            public int CompareTo(TNode other)
            {
                return Value.CompareTo(other);
            }

            public int CompareNode(BineryTreeNode<TNode> bineryTree)
            {
                return Value.CompareTo(bineryTree.Value);
            }
        }

        public _001_TreeNode()
        {
            BineryTreeNode<int> node1 = new BineryTreeNode<int>(5);
            BineryTreeNode<int> node2 = new BineryTreeNode<int>(3);
            BineryTreeNode<int> node3 = new BineryTreeNode<int>(8);

            if (node1.CompareNode(node2) >= 0)
                node1.Left = node2;
            else
                node1.Rigth = node2;

            if (node1.CompareNode(node3) >= 0)
                node1.Left = node3;
            else
                node1.Rigth = node3;

            Console.WriteLine($"{node1.Value}");
            Console.WriteLine($"{node1.Left.Rigth}");
            Console.WriteLine($"{node1.Left.Value}");

            Console.ReadLine();
        }

    }
}
