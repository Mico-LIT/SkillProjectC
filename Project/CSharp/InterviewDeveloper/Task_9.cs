using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.InterviewDeveloper
{
    class Task_9
    {
        public Task_9()
        {
            //decimal nominal = 0.1m;
            //decimal sum = 0.0m;

            float nominal = 0.1f;
            float sum = 0.0f;

            for (int i = 0; i < 100; i++)
            {
                sum += nominal;
                Console.WriteLine("{0:f25}  ==  0.9  {1}", sum, sum == 0.9);
            }

            Console.Read();
        }
    }
}
