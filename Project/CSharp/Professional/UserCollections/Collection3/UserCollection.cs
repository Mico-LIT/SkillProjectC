using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.UserCollections.Collection3
{
    class UserCollection<T>
    {
        readonly T[] element = new T[4];

        int position = -1;

        public T this[int index]
        {
            get { return element[index]; }
            set { element[index] = value; }
        }

        // Реализачия интерфейса IEnumerator
        object Current
        {
            get
            {
                return element[position];
            }
        }

       public IEnumerator GetEnumerator()
        {
            // Первый вариант
            while (true)
            {
                if (position < element.Length - 1)
                {
                    position++;
                    yield return element[position];
                }
                else
                {
                    Reset();
                    yield break;
                }
            }
            // Второй вариант

            //foreach (var item in element)
            //{
            //    yield return element;
            //}

            // Третий вариант

            //return element.GetEnumerator();
        }

        bool MoveNext()
        {
            if (position < element.Length -1)
            {
                position++;
                return true;
            }
            ((IEnumerator)this).Reset();
            return false;
        }

        void Reset()
        {
            position = -1;
        }
    }
}
