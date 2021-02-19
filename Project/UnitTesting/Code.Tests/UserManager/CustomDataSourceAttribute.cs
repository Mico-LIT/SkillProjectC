using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Code.Tests.UserManager
{
    public class CustomDataSourceAttribute : Attribute, ITestDataSource
    {
        public IEnumerable<object[]> GetData(MethodInfo methodInfo)
        {
            XDocument doc = XDocument.Load("UserManager\\DataUsers.xml");

            var users = doc.Root.Elements();

            foreach (var item in users)
            {
                List<string> vs = new List<string>();

                var noda = item.Attributes().First();
                do
                {
                    vs.Add(noda.Value);
                    noda = noda.NextAttribute;
                } while (noda != null);

                yield return vs.ToArray();
            }
        }

        public string GetDisplayName(MethodInfo methodInfo, object[] data)
        {
            if (data != null)
                return string.Format(CultureInfo.CurrentCulture, "Custom {0} - ({1})", methodInfo.Name, string.Join(',', data));

            return null;
        }
    }
}
