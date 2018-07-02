using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CSharp.Professional.UserCollections._ICollection.UICollection
{
    class UserCollection : ICollection
    {
        readonly object syncRoot = new object();
        readonly object[] elements = { 1, 2, 3, 4, 5 };

        // Возвращает число элементов, содержащиечся в коллекции ICollection
        public int Count
        {
            get
            {
                return elements.Length;
            }
        }
        // Получает значение, позволяющее определить, является ли доступ к коллекции ICollection синхронизации
        public bool IsSynchronized
        {
            get
            {
                return true;
            }
        }
        // Получает объект, который можно использовать для синхронизации доступа к ICollection
        public object SyncRoot
        {
            get
            {
                return syncRoot;
            }
        }

        public void CopyTo(Array array, int index)
        {
            var arr = array as object[];
            if (arr == null) throw new Exception("");

            for (int i = 0; i < array.Length; i++)
            {
                arr[index++] = elements[i];
            }

        }

        public IEnumerator GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    }
}
