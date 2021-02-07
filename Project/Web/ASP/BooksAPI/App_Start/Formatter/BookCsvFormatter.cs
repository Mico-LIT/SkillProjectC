using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http.Formatting;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using BooksAPI.Models;
using System.Text;
using BooksAPI.DTOs;

namespace BooksAPI.App_Start.Formatter
{
    public class BookCsvFormatter : BufferedMediaTypeFormatter
    {
        public BookCsvFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/csv"));
            // New code:
            //SupportedEncodings.Add(new UTF8Encoding(encoderShouldEmitUTF8Identifier: false));
            //SupportedEncodings.Add(Encoding.GetEncoding("iso-8859-1"));
        }

        public override bool CanReadType(Type type)
        {
            return false;
        }

        public override bool CanWriteType(Type type)
        {
            if (type == typeof(BookDto))
            {
                return true;
            }
            else
            {
                return typeof(IEnumerable<BookDto>).IsAssignableFrom(type);
            }
        }

        public override void WriteToStream(Type type, object value, Stream writeStream, HttpContent content)
        {
            //Encoding effectiveEncoding = SelectCharacterEncoding(content.Headers);
            //using (var writer = new StreamWriter(writeStream, effectiveEncoding))

            using (var writer = new StreamWriter(writeStream))
            {
                var books = value as IEnumerable<BookDto>;

                if (books != null)
                {
                    foreach (var item in books)
                        writerItem(item, writer);
                }
                else
                {
                    var singlBook = value as BookDto;

                    if (singlBook == null)
                        throw new Exception("Cannot serialize type");
                    writerItem(singlBook, writer);
                }
            }
        }

        private void writerItem(BookDto singlBook, StreamWriter writer)
        {
            writer.WriteLine(string.Format("{0};{1};{2}",
            Escape(singlBook.Genre),
            Escape(singlBook.Title),
            Escape(singlBook.Author)));
        }

        static char[] _specialChars = new char[] { ',', '\n', '\r', '"' };
        private object Escape(object o)
        {
            string text = o.ToString();

            if (string.IsNullOrEmpty(text))
                return string.Empty;

            if (text.IndexOfAny(_specialChars) != -1)
                return String.Format("\"{0}\"", text.Replace("\"", "\"\""));
            else
                return text;

        }
    }
}