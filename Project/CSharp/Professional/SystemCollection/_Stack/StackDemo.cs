using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.SystemCollection._Stack
{
    class StackDemo
    {
        public StackDemo()
        {
            Stack stack = new Stack();
            stack.Push("An Item");          // Push Добавляет элемент в конец стека
            Console.WriteLine(stack.Pop()); // Pop возвращает первый элемент стека, удаляет его
        }
    }
}
