using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Tests._08_TestAndClassInit_ShopingCard
{
    [TestClass]
    public class _001_TestInitAndCleanUp
    {
        _001_ShopingCard card;
        _001_ShopingCard.Item item;

        //Запускается перед стартом каждого тестирущего метода
        [TestInitialize]
        public void TestInitialize()
        {
            Debug.WriteLine("TestInitialize");

            item = new _001_ShopingCard.Item();
            item.Name = "Page";
            item.Quantity = 2;

            card = new _001_ShopingCard();
            card.Add(item);
        }

        //Запускается после каждого тестирущего метода
        [TestCleanup]
        public void TestCleanUp()
        {
            Debug.WriteLine("TestCleanUp");
            card.Dispose();
        }

        [TestMethod]
        public void ShopingCard_CheckOut_ContainsIten()
        {
            CollectionAssert.Contains(card.Items, item);
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
