using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.CircularBuffer
{
    class _003_CircularBuffer<T> : _002_Buffer<T>
    {
        int capacity;

        public bool IsFull => items.Count == capacity;

        public _003_CircularBuffer() : this(10)
        {
        }

        public _003_CircularBuffer(int count)
        {
            this.capacity = count;
        }

        public void Write(T value)
        {
            Write(value);

            if (items.Count > capacity)            
                items.Dequeue();
            
        }
    }
}
