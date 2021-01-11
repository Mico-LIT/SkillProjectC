using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.CircularBuffer
{
    class _002_Buffer<T> : IBuffer<T>, IEnumerable<T>
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
    }
}
