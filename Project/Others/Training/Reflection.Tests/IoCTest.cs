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

        [TestMethod]
        public void Can_Resolve_Types_Without_Default_Ctor()
        {
            var ioc = new Conteiner();
            ioc.For<ILogger>().Use<SqlServerLogger>();
            ioc.For<IRepository<Employee>>().Use<SqlRepository<Employee>>();

            var repository = ioc.Resolve<IRepository<Employee>>();

            Assert.AreEqual(typeof(SqlRepository<Employee>), repository.GetType());
        }
    }
}
