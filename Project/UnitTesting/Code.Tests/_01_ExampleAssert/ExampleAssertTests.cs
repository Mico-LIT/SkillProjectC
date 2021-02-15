using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Code.Tests._01_ExampleAssert
{
    [TestClass]
    public class ExampleAssertTests
    {
        [TestMethod]
        public void Sum_10plas20_30return()
        {
            //Arrange
            int x = 10;
            int y = 20;

            int expected = 30;

            //Act
            var c = new _003_ExampleAssert();
            int actual = c.Sum(x, y);

            //Assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void IsSqrtTest()
        {
            //Arrange
            int input = 4;
            int expected = 2;

            //Act
            double result = _003_ExampleAssert.GetSqrt(input);

            //Assert
            Assert.AreEqual(expected, result, "input {0}, expected {1}", input, expected);
        }


        [TestMethod]
        public void DeltaTest()
        {
            const double input = 10;
            const double delta = 0.07;
            const double expected = 3.1;

            // 3.1622776601683795
            double result = _003_ExampleAssert.GetSqrt(input);

            // Сравнение с учетом погрешности
            Assert.AreEqual(expected, result, delta, "Fail message");
        }

        [TestMethod]
        public void StringAreEqualTest()
        {
            string input = "HELLO";
            string expected = "hello";

            Assert.AreEqual(expected, input, true);
        }

        [TestMethod]
        public void StringAreSameTest()
        {
            string input = "HELLO";
            string expected = string.Intern("HELLO");

            Assert.AreSame(expected, input);
        }

        [TestMethod]
        public void IntegerAreSameTest()
        {
            int input = 1;
            int input2 = 1;

            Assert.AreSame(input, input2);
        }
    }
}
