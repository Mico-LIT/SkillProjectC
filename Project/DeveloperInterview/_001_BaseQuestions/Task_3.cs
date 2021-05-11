using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseQuestions
{
    class Task_3
    {
        /// <summary>
        /// TODO Не решенный вопрос!!!!!!!!!!
        /// </summary>
        public void Process()
        {
            List<Action> action = new List<Action>();
            for (int i = 0; i < 10; i++)
            {
                action.Add(new Action(()=> Trace.WriteLine(i)));
            }

            foreach (var item in action)
            {
                item();
            }
            Console.ReadLine();
        }
    }
}
