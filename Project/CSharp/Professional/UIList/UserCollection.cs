using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.UIList
{
    class UserCollection : IList
    {
        private readonly object[] contains = new object[8];

        private int count;

        public UserCollection()
        {
            this.count = 0;
        }

        public object this[int index]
        {
            get => contains[index];
            set => contains[index] = value;
        }

        public bool IsReadOnly => false;

        public bool IsFixedSize => true;

        public int Count => count;

        // получает объект, который можно использовать для синхронизации доступа к ICollection
        public object SyncRoot => null;

        // нельзя обращаться из нескольких потоков
        public bool IsSynchronized => false;

        /// <summary>
        /// Добавляет элемент в список Ilist
        /// </summary>
        /// <param name="value">элемент который требуется поместить в коллекцию</param>
        /// <returns>Индекс элемента</returns>
        public int Add(object value)
        {
            if (count < contains.Length)
            {
                contains[count] = value;
                count++;
                return count - 1;
            }
            return -1;
        }

        public void Clear()
        {
            count = 0;
        }

        // содержится ли значение в списке IList
        public bool Contains(object value)
        {
            for (int i = 0; i < contains.Length; i++)
            {
                if (contains[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        // Копирует элементы ICollection в Array, наиная с конкретного индекса
        public void CopyTo(Array array, int index)
        {
            int j = index;
            for (int i = 0; i < count; i++)
            {
                array.SetValue(contains[i], j);
                j++;
            }
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return contains[i];
            }
        }

        public int IndexOf(object value)
        {
            for (int i = 0; i < contains.Length; i++)
            {
                if (contains[i] == value)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Insert(int index, object value)
        {
            if ((index >= 0) && (count > index) && (count + 1 <= contains.Length))
            {
                count++;
                for (int i = count - 1; i > index; i--)
                {
                    contains[i] = contains[i - 1];  
                }
                contains[index] = value;
            }
        }

        public void Remove(object value)
        {
            RemoveAt(IndexOf(value));
        }

        public void RemoveAt(int index)
        {
            if ((index >= 0) && (index < count))
            {
                for (int i = index; i < count - 1; i++)
                {
                    contains[i] = contains[i + 1];
                }
                    count--;
            }
        }
    }
}
