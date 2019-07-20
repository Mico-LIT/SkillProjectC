using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharp.Base.Threading.TPL._Parallel
{
    class Element
    {
        public int A { get; set; }
    }

    public class _003_ForEach
    {
        //object loker = new object();

        public _003_ForEach()
        {
            IList<Element> elements = new List<Element>();

            Action<int> initialize = (i) =>
            {
                    elements.Add(new Element() { A = i });
            };

            Parallel.For(0, 1000, initialize);

            elements[300].A = -1;

            Action<Element, ParallelLoopState> transform = (Element el, ParallelLoopState pl) =>
             {

                 if (el.A < 0)
                     pl.Break();

                 Thread.Sleep(1);

                 el.A = 111 * 33 * 555 / 444;
             };


            ParallelLoopResult loopResult = Parallel.ForEach(elements, transform);

            if (!loopResult.IsCompleted)
            {
                Console.WriteLine(loopResult.LowestBreakIteration);
            }

            Console.ReadLine();
        }
    }
}
