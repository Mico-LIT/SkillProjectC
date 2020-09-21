using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.Trees
{
    class _003_BinaryTree
    {
        class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
        {
            _001_TreeNode.BineryTreeNode<T> _head;

            public int Count { get; private set; }

            public void Add(T item)
            {
                if (_head == null)
                    _head = new _001_TreeNode.BineryTreeNode<T>(item);
                else
                    AddTo(_head, item);

                Count++;
            }

            public bool Contains(T value)
            {
                _001_TreeNode.BineryTreeNode<T> parent;
                return FindWithParent(value, out parent) != null;
            }

            //Find
            private _001_TreeNode.BineryTreeNode<T> FindWithParent(T value, out _001_TreeNode.BineryTreeNode<T> parent)
            {
                _001_TreeNode.BineryTreeNode<T> current = _head;
                parent = null;

                while (current != null)
                {
                    int result = current.CompareTo(value);

                    if (result > 0)
                    {
                        parent = current;
                        current = current.Left;
                    }
                    else if (result < 0)
                    {
                        parent = current;
                        current = current.Rigth;
                    }
                    else
                        break;
                }

                return current;
            }

            private void AddTo(_001_TreeNode.BineryTreeNode<T> node, T value)
            {
                if (node.CompareTo(value) > 0)
                {
                    if (node.Left == null)
                        node.Left = new _001_TreeNode.BineryTreeNode<T>(value);
                    else
                        AddTo(node.Left, value);
                }
                else
                {
                    if (node.Rigth == null)
                        node.Rigth = new _001_TreeNode.BineryTreeNode<T>(value);
                    else
                        AddTo(node.Rigth, value);
                }
            }

            public IEnumerator<T> GetEnumerator()
            {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }


        public _003_BinaryTree()
        {
            var binaryTree = new BinaryTree<int>();

            binaryTree.Add(1);
            binaryTree.Add(3);
            binaryTree.Add(5);
            binaryTree.Add(2);
            binaryTree.Add(8);


            Console.WriteLine($"Contains: {binaryTree.Contains(2)}");
            Console.WriteLine($"Contains: {binaryTree.Contains(12)}");

            Console.Read();
        }
    }
}
