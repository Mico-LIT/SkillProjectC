using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Code.Tests
{
    [TestClass]
    public class MyCalcTests
    {
        [TestMethod]
        public void Sum_10plas20_30return()
        {
            //Arrange
            int x = 10;
            int y = 20;

            int expected = 30;

            //Act
            var c = new MyCalc();
            int actual = c.Sum(x, y);

            //Assert
            Assert.AreEqual(actual, expected);
        }
    }
}
