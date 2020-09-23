using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.Trees
{
    /// <summary>
    /// 'Реализован метод удаления'
    /// 
    /// Первый вариант: удаляемый узел не имеет правого потомка
    /// Второй вариант: удаляемый узел имеет правого потомка, у которого нет левого потомка
    /// Третий вариант: удаляемый узел имеет правого потомка у которого есть левый потомок
    /// 
    /// </summary>
    class _004_BinaryTree
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

            bool Remove(T value)
            {
                _001_TreeNode.BineryTreeNode<T> current;
                _001_TreeNode.BineryTreeNode<T> parent;

                current = this.FindWithParent(value, out parent);
                if (current == null) return false;

                Count--;

                // Первый вариант: удаляемый узел не имеет правого потомка 
                if (current.Rigth == null)
                {
                    if (parent == null) _head = current.Left;
                    else
                    {
                        var result = parent.CompareNode(current);

                        if (result > 0) parent.Left = current.Left;
                        else
                        if (result < 0) parent.Rigth = current.Left;
                    }
                }
                // Второй вариант: удаляемый узел имеет правого потомка, у которого нет левого потомка
                else if (current.Rigth.Left == null)
                {
                    current.Rigth.Left = current.Left;

                    if (parent == null) _head = current.Rigth;
                    else
                    {
                        var result = parent.CompareTo(value);
                        if (result > 0)
                            parent.Left = current.Rigth;
                        else
                            parent.Rigth = current.Rigth;
                    }

                }
                // Третий вариант: удаляемый узел имеет правого потомка у которого есть левый потомок
                else
                {

                }





                return true;
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

        public _004_BinaryTree()
        {
        }
    }
}
