using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Tests._07_InternalClass
{
    [TestClass]
    public class _01_ExampleTest
    {
        [TestMethod]
        public void TestExample()
        {
            var example = new InternalClassTest._001_Example();
            bool result = example.Tmp();

            Assert.IsTrue(result);
        }
    }
}
