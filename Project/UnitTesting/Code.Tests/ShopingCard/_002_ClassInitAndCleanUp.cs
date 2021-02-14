using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Tests.ShopingCard
{
    [TestClass]
    public class _002_ClassInitAndCleanUp
    {
        static _001_ShopingCard card;

        // Запускается перед стартом перевого тестирущего метода (один раз)
        // Метод должен быть окрытым, статическим и принимать параметр типа
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            Debug.WriteLine("ClassInitialize");

            var item = new _001_ShopingCard.Item();
            item.Name = "Page";
            item.Quantity = 2;

            card = new _001_ShopingCard();
            card.Add(item);
        }

        // Запускается после завершения последнего тестирущего метода (один раз)
        [ClassCleanup]
        public static void ClassCleanup()
        {
            Debug.WriteLine("ClassCleanup");
            card.Dispose();
        }

        [TestMethod]
        public void ShopingCard_CheckOut_ContainsIten()
        {
            CollectionAssert.Contains(card.Items, card.Items.First());
        }

        [TestMethod]
        public void ShopingCard_RemoveItems_Empty()
        {
            //Arrange
            int expected = 0;
            //Act
            card.Removed(0);
            //Assert
            Assert.AreEqual(expected, card.Count);
        }
    }
}
