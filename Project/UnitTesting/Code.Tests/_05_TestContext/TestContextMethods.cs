using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Tests._05_TestContext
{
    [TestClass]
    public class TestContextMethods
    {
        // TestContext для хранении информации о текущем юник тесте 
        // При тестирование web services хранит URL
        // При тестировании ASP.NET приложений - передоставляет доступ к ASP страницам
        // При исполизовании Data Driven тестов предоставляет доступ источнику данных
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestMethod1()
        {
            TestContext.WriteLine("TestRunDirectory {0}", TestContext.TestRunDirectory);
            TestContext.WriteLine("TestName {0}", TestContext.TestName);
            TestContext.WriteLine("CurrentTestOutcome {0}", TestContext.CurrentTestOutcome);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine("(CleanUp) {0}", TestContext.TestName);
            TestContext.WriteLine("(CleanUp) {0}", TestContext.CurrentTestOutcome);
        }
    }
}
