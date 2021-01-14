using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.CircularBuffer
{
    static class BufferExtensions
    {
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
