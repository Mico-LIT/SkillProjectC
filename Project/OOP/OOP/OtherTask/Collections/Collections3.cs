using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Collections
{
    class Collections3
    {
        public Collections3()
        {
            //Push: добавляет элемент в стек на первое место
            //Pop: извлекает и возвращает первый элемент из стека
            //Peek: просто возвращает первый элемент из стека без его удаления

            Stack<int> stack = new Stack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine(stack.Pop());
            Console.WriteLine(new string('_',20));

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.ReadLine();
        }
    }
}
