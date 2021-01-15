namespace CSharp.Base.UniversalTemplate.CircularBuffer.Interfaces
{
    using System.Collections.Generic;
    interface IBuffer<T> : IEnumerable<T>
    {
        bool IsEmpty { get; }
        T Read();
        void Write(T value);
    }
}