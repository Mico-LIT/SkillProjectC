using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.OtherTask.Collections.UserCollections
{
    class Element
    {
        private string myProperty1;
        private string myProperty2;
        private string name;

        public Element(string s1, string s2, string s3)
        {
            this.myProperty1 = s1;
            this.myProperty2 = s2;
            this.name = s3;
        }

        public string MyProperty1
        {
            get
            {
                return myProperty1;
            }
            set
            {
                myProperty1 = value;
            }
        }
        public string MyProperty2
        {
            get
            {
                return myProperty2;
            }
            set
            {
                myProperty2 = value;
            }
        }
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
    }
}
