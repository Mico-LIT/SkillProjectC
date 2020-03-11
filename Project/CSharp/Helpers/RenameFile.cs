using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CSharp.Helpers
{
    class RenameFile
    {
        public void FileRename()
        {
            string _Path = @"C:\Users\it30\Desktop\КАРТИНКИ ДЛЯ ПО ИЮЛЬ_2018";
            string Monht = "07";

            IEnumerable<FileInfo> FileArr = Directory.GetFiles(_Path).Select(x => new FileInfo(x));
            StringBuilder str = new StringBuilder();
            int i = 1;
            foreach (FileInfo item in FileArr)
            {
                if (i <= 9) str.AppendFormat("0{0}", i);
                else str.AppendFormat("{0}", i);
                File.Move(item.FullName, $"{str.ToString()}_{Monht}{item.Extension}");
                i++;
                str.Clear();
            }
        }
    }
}
