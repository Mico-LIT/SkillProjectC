using System;
using TaskSafeColl = System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.Collections.ConcurrentColl
{
    class _001_Class1
    {
        public _001_Class1()
        {
            // Потоко безопастные коллекции
            TaskSafeColl.ConcurrentBag<int> vs = new TaskSafeColl.ConcurrentBag<int>();
            vs.Add(1);
            vs.Add(1);

            TaskSafeColl.ConcurrentDictionary<int, string> keyValuePairs = new TaskSafeColl.ConcurrentDictionary<int, string>();
            TaskSafeColl.ConcurrentQueue<string> vs1 = new TaskSafeColl.ConcurrentQueue<string>();
        }
    }
}
