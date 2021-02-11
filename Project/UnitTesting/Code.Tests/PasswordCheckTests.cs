using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Tests
{
    [TestClass]
    public class PasswordCheckTests
    {
        [TestMethod()]
        public void GetPasswordStrength_AllChars_Result5Ballov()
        {
            //Arrange
            string pass = "Pasv123!";
            int result = 5;
            //Act
            int strengthPass = new PasswordCheck().GetPasswordStrength(pass);


            //Assert
            Assert.AreEqual(result, strengthPass);
        }
    }
}
