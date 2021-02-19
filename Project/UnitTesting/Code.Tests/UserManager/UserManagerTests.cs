using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Tests.UserManager
{
    [TestClass]
    public class UserManagerTests
    {
        //[DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "DataUsers.xml", "User", DataAccessMethod.Random)]

        // TestContext.DataRow => В Core не используется!!
        //public TestContext TestContext { get; set; }

        [TestMethod]
        [DataRow("4566874AAA", "+7865154", "test222@gmail.com")]
        [DataRow("333yyy1", "+785469514", "test@gmail.com")]
        public void UserManager_CheckAddMethodDataRow_ResultValidDate(string userId, string phone, string email)
        {
            bool result = new _004_UserManager().Add(userId, phone, email);
            Assert.IsTrue(result, "Falid");
        }

        [DataTestMethod]
        [DataRow("4566874AAA", new object[] { "+785469514", "test@gmail.com" })] // Explicit array construction
        public void UserManager_CheckAddDataRowExemple_ResultValidDate(string userId, string phone, string email)
        {
            bool result = new _004_UserManager().Add(userId, phone, email);
            Assert.IsTrue(result, "Falid");
        }

        [DataTestMethod]
        [CustomDataSource]
        public void UserManager_CheckAddMethodCustomDataSource_ResultValidDate(string userId, string phone, string email)
        {
            bool result = new _004_UserManager().Add(userId, phone, email);
            Assert.IsTrue(result, "Falid");
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void UserManager_CheckAddDynamicData_ResultValidDate(string userId, string phone, string email)
        {
            bool result = new _004_UserManager().Add(userId, phone, email);
            Assert.IsTrue(result, "Falid");
        }

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { "4566874AAA", "+785469514", "test@gmail.com" };
        }
    }
}
