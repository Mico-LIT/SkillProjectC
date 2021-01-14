namespace CSharp.Base.UniversalTemplate.CircularBuffer
{
    using System.Collections.Generic;
    interface IBuffer<T> : IEnumerable<T>
    {
        bool IsEmpty { get; }
        T Read();
        void Write(T value);
    }
}