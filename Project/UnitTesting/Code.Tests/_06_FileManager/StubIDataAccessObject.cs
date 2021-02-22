using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Tests._06_FileManager
{
    internal class StubIDataAccessObject : _005_FileManager.IDataAccessObject
    {
        public IList<string> GetFiles()
        {
            return new List<string>()
                {
                    "test.txt",
                    "dev.txt",
                    "Demo.txt",
                };
        }
    }
}
