using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.UniversalTemplate.CircularBuffer
{
    /// <summary>
    /// Кольцевой буфер. Популярность КБ Обусловлена тем, что это один из самых простых
    /// и эффективных способ организовать FIFO
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class _001_CircularBuffer<T>
    {
        T[] buffer;
        int head;
        int tail;

        public int Capacity => buffer.Length;
        public bool IsEmpty => head == tail;
        public bool IsFull => (tail + 1) % Capacity == head;

        public _001_CircularBuffer() : this(3)
        {
        }

        public _001_CircularBuffer(int count)
        {
            buffer = new T[count + 1];
            head = 0;
            tail = 0;
        }

        public void Write(T value)
        {
            buffer[tail] = value;
            tail = (tail + 1) % Capacity;

            if (head == tail)
                head = (head + 1) % Capacity;
        }

        public T Read()
        {
            var result = buffer[head];
            head = (head + 1) % Capacity;
            return result;
        }
    }
}
