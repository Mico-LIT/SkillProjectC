using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.UserCollections.Collection2
{
    class UserCollection<T> : IEnumerable<T>, IEnumerator<T>
    {
        readonly T[] element = new T[4];

        int position = -1;

        public T this[int index]
        {
            get { return element[index]; }
            set { element[index] = value; }
        }

        T IEnumerator<T>.Current
        {
            get
            {
                return element[position];
            }
        }

        // Реализачия интерфейса IEnumerator
        object IEnumerator.Current
        {
            get
            {
                return element[position];
            }
        }

        void IDisposable.Dispose()
        {
            ((IEnumerator)this).Reset();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this;
        }

        bool IEnumerator.MoveNext()
        {
            if (position < element.Length -1)
            {
                position++;
                return true;
            }
            ((IEnumerator)this).Reset();
            return false;
        }

        void IEnumerator.Reset()
        {
            position = -1;
        }


    }
}
