using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Collections.UserCollections
{
    class UserCollection : IEnumerable, IEnumerator
    {

        Element[] elem = null;

        public UserCollection()
        {
            elem = new Element[4];
            elem[0] = new Element("1","2","3");
            elem[1] = new Element("11", "2", "3");
            elem[2] = new Element("111", "2", "3");
            elem[3] = new Element("11211", "2", "3");
        }

        int position = -1;

        public object Current
        {
            get
            {
               return elem[position];
            }
        }

        public bool MoveNext()
        {
            if ((elem.Length-1) > position)
            {
                position++;
                return true;
            }
            else
            {
               this.Reset();
               return false;
            }
        }

        public void Reset()
        {
            position = -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this as IEnumerator;
        }
    }
}
