using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.UserCollections._ICollection.UICollection2
{
    class UserCollection<T> : ICollection<T>
    {
        T[] elements = new T[0];

        public int Count => elements.Length;

        public bool IsReadOnly => false;

        // Добавляет элемент в интерфейс ICollection<T>
        public void Add(T item)
        {
            var newelement = new T[elements.Length + 1]; // Создание нового массива(на 1 болльше старого)
            elements.CopyTo(newelement,0);               // комирование старого массива в новый
            newelement[newelement.Length - 1] = item;    // Помещение нового значения в конец массива.
            elements = newelement;                       // Замена старого массива на новый 
        }

        // Удаляет все элементы из коллекции ICollection<T>
        public void Clear()
        {
            elements = new T[0];
        }

        // Определяет содержит ли интерфейс  ICollection<T> указанное значение 
        public bool Contains(T item)
        {
            foreach (var _item in elements)
            {
                if(_item.Equals(item)) return true;
            }
            return false;

            /// Linq
            /// return elements.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            elements.CopyTo(array, arrayIndex);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return ((IEnumerable<T>)elements).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (this as IEnumerable<T>).GetEnumerator();
        }

        bool ICollection<T>.Remove(T item)
        {
            throw new NotImplementedException();
        }
    }
}
