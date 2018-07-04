using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Professional.ProgrammingIO.Compressor
{
    class _GZipStream
    {
        public _GZipStream()
        {
            // Создание фала и архива
            FileStream source = File.OpenRead(@"Text.txt");
            FileStream distin = File.Create(@"archive.zip");

            // Создание компрессора
            GZipStream compress = new GZipStream(distin, CompressionMode.Compress);

            int theByte = source.ReadByte();
            do
            {
                compress.WriteByte((byte)theByte);
                theByte = source.ReadByte();
            } while (theByte != -1);

            compress.Close();
        }
    }
}
