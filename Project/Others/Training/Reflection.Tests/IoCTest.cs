using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Reflection.Tests
{
    [TestClass]
    public class IoCTest
    {
        [TestMethod]
        public void Can_Resolve_Types()
        {
            var ioc = new Conteiner();
            ioc.For<ILogger>().Use<SqlServerLogger>();

            var logger = ioc.Resolve<ILogger>();

            Assert.AreEqual(typeof(SqlServerLogger), logger.GetType());
        }
    }
}
