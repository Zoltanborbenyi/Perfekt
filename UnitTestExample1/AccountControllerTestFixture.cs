using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Threading.Tasks;


namespace UnitTestExample.Test
{
    [TestFixture] 
    public class AccountControllerTestFixture
    {
        [TestCase("abcd1234", false)]
        [TestCase("irf@uni-corvinus", false)]
        [TestCase("irf.uni-corvinus.hu", false)]
        [TestCase("irf@uni-corvinus.hu", true)]
        [Test]
        public void TestValidateEmail(string email, bool expectedResult)
        {
            // Arrange
            var accountController = new Controllers.AccountController();

            // Act
            var actualResult = accountController.ValidateEmail(email);

            // Assert
            Assert.That(actualResult, Is.EqualTo(expectedResult));

        }

        [TestCase("irf@uni-corvinus.hu", "Abcd1234")]
        [TestCase("irf@uni-corvinus.hu", "Abcd1234567")]
        public void TestRegisterHappyPath(string email, string password)
        {
            // Arrange
            var accountController = new Controllers.AccountController();

            // Act
            var actualResult = accountController.Register(email, password);

            // Assert
            // Assert
            Assert.That(actualResult.Email, Is.EqualTo(email));
            Assert.That(actualResult.Password, Is.EqualTo(password));
            Assert.That(actualResult.ID, Is.Not.EqualTo(Guid.Empty));

        }
    }
}
