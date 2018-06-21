using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.InterviewDeveloper
{
    class Task_4
    {
        public void Process()
        {
            int i = 1;
            object obj = i;
            ++i;
            Console.WriteLine(i); // 2
            Console.WriteLine(obj); // 1
            Console.WriteLine((short)obj); // Ошибка
        }
    }
}
