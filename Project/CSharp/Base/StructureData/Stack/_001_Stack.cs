using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.StructureData.Stack
{
    // Реализация на основе 2-х связного списка
    class _001_Stack
    {
        class Stack<T>
        {
            LinkedList<T> _items = new LinkedList<T>();

            public int Count => _items.Count;

            public void Push(T item)
            {
                _items.AddLast(item);
            }

            public T Pop()
            {
                if (_items.Count == 0)
                    throw new InvalidOperationException("Stack empty");

                T result = _items.Last.Value;
                _items.RemoveLast();

                return result;
            }

            public T Peek()
            {
                return _items.Last.Value;
            }

        }


        public _001_Stack()
        {
            Stack<int> stack = new Stack<int>();

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);

            Console.WriteLine("Top stack {0}", stack.Peek());

            var result = stack.Pop();
            var result1 = stack.Pop();

            Console.WriteLine();
            Console.WriteLine("Top stack {0}", stack.Peek());
            Console.WriteLine("Count {0}", stack.Count);

        }
    }
}
