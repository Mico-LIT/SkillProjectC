using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Tests._06_FileManager
{
    [TestClass]
    public class _01_FileManagerFindFileTests
    {
        [TestMethod]
        public void FindFile_FindFile_Found()
        {
            //Arrange
            var stubObj = new StubIDataAccessObject();
            var expected = true;
            string fileName = "test.txt";

            //Act
            var fileManager = new _005_FileManager();
            expected = fileManager.FindFile(fileName, stubObj); //dependency injection

            //Assert
            Assert.IsTrue(expected, "File {0} was not found", fileName);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetData), DynamicDataSourceType.Method)]
        public void FindFile_FindFile_Found_2(_005_FileManager.IDataAccessObject stubObj)
        {
            //Arrange
            var expected = true;
            string fileName = "test.txt";

            //Act
            var fileManager = new _005_FileManager();
            expected = fileManager.FindFile(fileName, stubObj); //dependency injection

            //Assert
            Assert.IsTrue(expected, "File {0} was not found", fileName);
        }

        public static IEnumerable<object[]> GetData()
        {
            yield return new object[] { new StubIDataAccessObject() };
        }        
    } 
}
