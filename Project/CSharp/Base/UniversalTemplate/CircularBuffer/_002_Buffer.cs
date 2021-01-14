using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.CircularBuffer
{
    class _002_Buffer<T> : IBuffer<T>
    {
        protected Queue<T> items = new Queue<T>();
        public virtual bool IsEmpty => items.Count == 0;

        public virtual T Read()
        {
            return items.Dequeue();
        }

        public virtual void Write(T value)
        {
            items.Enqueue(value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public IEnumerable<TOutput> AsEnumerableOf<TOutput>()
        {
            var convertor = System.ComponentModel.TypeDescriptor.GetConverter(typeof(T));
            foreach (var item in items)
            {
                var result = convertor.ConvertTo(item, typeof(TOutput));
                yield return (TOutput)result;
            }
        }
    }
}
