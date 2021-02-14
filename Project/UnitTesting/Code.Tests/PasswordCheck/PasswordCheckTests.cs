using Code;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Tests.PasswordCheck
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
            int strengthPass = new _002_PasswordCheck().GetPasswordStrength(pass);


            //Assert
            Assert.AreEqual(result, strengthPass);
        }

        [TestMethod()]
        public void GetPasswordStrength_DigitalAndChars_Result3Balloc()
        {
            //Arrange
            string pass = "1qaz2wsx3edc";
            int result = 3;
            //Act
            var sthrenthPass = new _002_PasswordCheck().GetPasswordStrength(pass);
            //Assert
            Debug.WriteLine(sthrenthPass);
            Assert.AreEqual(sthrenthPass, result);
        }
    }
}
