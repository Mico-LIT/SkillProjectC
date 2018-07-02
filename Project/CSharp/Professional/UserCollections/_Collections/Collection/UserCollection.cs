using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.UserCollections._Collection.Collection
{
    class UserCollection : IEnumerable, IEnumerator
    {
        readonly Element[] element = new Element[4];

        int position = -1;

        public Element this[int index]
        {
            get { return element[index]; }
            set { element[index] = value; }
        }

        // Реализачия интерфейса IEnumerator
        object IEnumerator.Current
        {
            get
            {
                return element[position];
            }
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
