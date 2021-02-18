using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Tests._04_ExpectingExceptions
{
    [TestClass]
    public class ExpectingExceptionsMethods
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Exception not throw")]
        public void Example_SeyHello_returnException()
        {
            new _003_ExampleAssert().SeyHello(null);
        }

        [TestMethod]
        public void Example_SeyHello_FullString()
        {
            // Arrange
            string expected = "Hello misha";
            string input = "misha";

            // Act
            var result = new _003_ExampleAssert().SeyHello(input);
            // Assert
            Assert.AreEqual(expected, result);
        }


    }
}
