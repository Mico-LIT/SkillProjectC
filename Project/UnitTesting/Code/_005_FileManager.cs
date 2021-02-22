using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code
{
    public class _005_FileManager
    {
        public bool FindFile(string fileName, IDataAccessObject dataAccess)
        {
            if (dataAccess == null)            
                throw new ArgumentNullException(nameof(dataAccess));            

            var files = dataAccess.GetFiles();

            return files.Any(x => x == fileName);
        }


        #region IDataAccessObject
        public class DataAccess : IDataAccessObject
        {
            public IList<string> GetFiles()
            {
                string path = Directory.GetCurrentDirectory();
                var directoryInfo = new DirectoryInfo(path);

                var fileInfos = from x in directoryInfo.GetFiles() select x.Name;

                return fileInfos.ToList();
            }
        }

        public interface IDataAccessObject
        {
            IList<string> GetFiles();
        }
        #endregion
    }
}
