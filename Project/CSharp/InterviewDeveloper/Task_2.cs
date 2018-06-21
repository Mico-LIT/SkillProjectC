using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.InterviewDeveloper
{
    class Task_2
    {
        public struct S : IDisposable
        {
            private bool dispose;
            public void Dispose()
            {
                dispose = true;
            }
            public bool GetDispose()
            {
                return dispose;
            }
        }

        /// <summary>
        /// Что будет выведено в следующем случае:
        /// true, true
        /// true, false
        /// false, true
        /// false, false +
        /// </summary>
        public void Process()
        {
            var s = new S();
            using (s)
            {
                Console.WriteLine(s.GetDispose());
            }
            Console.WriteLine(s.GetDispose());
        }
    }
}
