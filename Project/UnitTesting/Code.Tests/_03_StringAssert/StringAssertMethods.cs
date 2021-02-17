using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Tests._03_StringAssert
{
    [TestClass]
    public class StringAssertMethods
    {
        [TestMethod]
        public void ContainsTest()
        {
            StringAssert.Contains("Hello misha", "is");
        }

        [TestMethod]
        public void MatchesTest()
        {
            StringAssert.Matches("gfd1", new System.Text.RegularExpressions.Regex(@"\d{1}"));
        }

        [TestMethod]
        public void EndsWithTest()
        {
            StringAssert.EndsWith("Hello misha", "misha");
        }

        [TestMethod]
        public void StartsWithTest()
        {
            StringAssert.StartsWith("hello misha", "hello");
        }
    }
}
