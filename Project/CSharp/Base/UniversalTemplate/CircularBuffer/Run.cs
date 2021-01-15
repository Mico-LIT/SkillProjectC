using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.CircularBuffer
{
    class Run
    {
        public Run()
        {
            Action action = () => { };
            Action<bool> action2 = (x) => { };

            Func<bool> func = () => { return true; };
            Func<bool,bool> func2 = (x) => { return x; };

            Predicate<int> predicate = (x) => { return x > 10; };

            Converter<double, string> converter = (x) => { return x.ToString(); };

            var buffer = new CSharp.Base.UniversalTemplate.CircularBuffer._003_CircularBuffer<double>();
            buffer.Write(1.2);
            buffer.Write(1.8);
            buffer.Write(2.3);

            buffer.Print();            

            var itemsAsInt = buffer.AsEnumerableOf<int>();
            var itemsMapString = buffer.Map(converter);


            foreach (var item in itemsAsInt)            
                Console.WriteLine(item);

            foreach (var item in itemsMapString)
                Console.WriteLine(item);
        }
    }
}
