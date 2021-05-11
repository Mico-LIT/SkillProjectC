using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _002_Parsing_CBR.Utilit
{
    public static class HtmlHelper
    {
        public static string ElementByName(this string str, string nameElementHtml)
        {
            string responseContent = str;

            var elementIndexOf = responseContent.IndexOf($"<{nameElementHtml}");
            if (elementIndexOf < 0)
            {
                elementIndexOf = responseContent.IndexOf($"<{nameElementHtml}>");
                if (elementIndexOf < 0)
                    return string.Empty;
            }

            responseContent = responseContent.Substring(elementIndexOf);

            var rows = responseContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            StringBuilder stringBuilder = new StringBuilder();

            // открытие и закрытие элемента
            int fullElementStatus = 0;

            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].IndexOf($"<{nameElementHtml}") >= 0 || rows[i].IndexOf($"<{nameElementHtml}>") >= 0)
                {
                    fullElementStatus++;
                }

                if (rows[i].IndexOf($"</{nameElementHtml}>") >= 0)
                {
                    fullElementStatus--;

                    if (fullElementStatus == 0)
                    {
                        for (int q = 0; q < i + 1; q++)
                            stringBuilder.Append(rows[q] + Environment.NewLine);

                        return stringBuilder.ToString();
                    }
                }
            }

            return "";
        }

        public static string ElementById(this string str, string name)
        {
            string responseContent = str;

            var elementIndexOf = responseContent.IndexOf($"id=\"{name}\"");

            responseContent = responseContent.Substring(elementIndexOf);

            for (int i = elementIndexOf; i > 0; i--)
            {
                if (str[i] == '<')
                {
                    responseContent = str.Substring(i);
                    break;
                }
            }

            var elementNameHtml = responseContent.Substring(1, responseContent.IndexOf(' ') - 1);

            var rows = responseContent.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            StringBuilder stringBuilder = new StringBuilder();

            // открытие и закрытие элемента
            int fullElementStatus = 0;

            for (int i = 0; i < rows.Length; i++)
            {
                if (rows[i].IndexOf($"<{elementNameHtml}") >= 0 || rows[i].IndexOf($"<{elementNameHtml}>") >= 0)
                {
                    fullElementStatus++;
                }

                if (rows[i].IndexOf($"</{elementNameHtml}>") >= 0)
                {
                    fullElementStatus--;

                    if (fullElementStatus == 0)
                    {
                        for (int q = 0; q < i + 1; q++)
                            stringBuilder.Append(rows[q] + Environment.NewLine);

                        return stringBuilder.ToString();
                    }
                }
            }

            return "";
        }

        public static string ElementsByTag(this string str, string nameTag)
        {
            return "";
        }
    }
}
