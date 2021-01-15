using CSharp.Base.UniversalTemplate.CircularBuffer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.CircularBuffer
{
    static class BufferExtensions
    {
        public static void Print<T>(this IBuffer<T> items)
        {
            foreach (var item in items)
                Console.WriteLine(item);
        }

        public static IEnumerable<TOutput> Map<T, TOutput>(this IBuffer<T> items, Converter<T, TOutput> converter)
        {
            return items.Select(x => converter(x));
        }

        public static IEnumerable<TOutput> AsEnumerableOf<T, TOutput>(this IBuffer<T> buffer)
        {
            var convert = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));

            foreach (var item in buffer)
            {
                TOutput result = (TOutput)convert.ConvertTo(item, typeof(TOutput));
                yield return result;
            }
        }
    }
}
