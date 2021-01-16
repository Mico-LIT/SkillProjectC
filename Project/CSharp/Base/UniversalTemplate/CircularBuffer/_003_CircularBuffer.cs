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

        public event EventHandler<ItemDiscardedEventEargs<T>> ItemDiscardedEvent;

        public bool IsFull => items.Count == capacity;

        public _003_CircularBuffer() : this(10)
        {
        }

        public _003_CircularBuffer(int count)
        {
            this.capacity = count;
        }

        public override void Write(T value)
        {
            base.Write(value);

            if (items.Count > capacity)
            {
                var oldValue = items.Dequeue();
                OnItemDiscarded(oldValue, value);
            }
            
        }

        private void OnItemDiscarded(T oldValue, T value)
        {
            if (ItemDiscardedEvent != null)            
                ItemDiscardedEvent(this, new ItemDiscardedEventEargs<T>(oldValue, value));            
        }

        public class ItemDiscardedEventEargs<T> : EventArgs
        {
            public ItemDiscardedEventEargs(T itemDiscarded, T newItem)
            {
                ItemDiscarded = itemDiscarded;
                NewItem = newItem;
            }

            public T ItemDiscarded { get; set; }
            public T NewItem { get; set; }

        }
    }
}
