using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.Trees
{
    /// <summary>
    /// Реализован метод добавления
    /// </summary>
    class _002_BinaryTree
    {
        class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
        {
            _001_TreeNode.BineryTreeNode<T> _head;
            int _count;
            public int Count => _count;

            // Adde item
            public void Add(T item)
            {
                if (_head == null)
                    _head = new _001_TreeNode.BineryTreeNode<T>(item);
                else
                {
                    AddTo(_head, item);
                }

                _count++;
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

        public _002_BinaryTree()
        {
            var instance = new BinaryTree<int>();

            instance.Add(5);
            instance.Add(4);
            instance.Add(3);
            instance.Add(11);
            instance.Add(10);
            instance.Add(8);

            Console.WriteLine($"instance.Count: {instance.Count}");
            Console.ReadLine();
        }

    }
}
