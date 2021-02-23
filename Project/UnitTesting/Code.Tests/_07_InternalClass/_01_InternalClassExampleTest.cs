using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Tests._07_InternalClass
{
    [TestClass]
    public class _01_InternalClassExampleTest
    {
        [TestMethod]
        public void TestExample_Tmp()
        {
            var example = new _006_InternalClassExample();
            bool result = example.Tmp();

            Assert.IsTrue(result);
        }
    }
}
