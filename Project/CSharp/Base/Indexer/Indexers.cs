using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Base.Indexer
{
    public class Indexers : IIndexers
    {
        readonly string[] arr = new string[] { "AKhil", "Bob", "Shawn", "Sandra" };

        public string this[int indexValue]
        {
            get
            {
                return arr[indexValue];
            }

            set
            {
                arr[indexValue] = value;
            }
        }
    }

    interface IIndexers
    {
      string this[int indexValue] { get;set; }
    }
}
