using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumDemoblaze.Pages;
using SeleniumDemoblaze.Payload;

namespace SeleniumDemoblaze.Tests
{
    public class SignUpTest : BaseTest
    {
        [Test]
        public void GivenANonEmptyUsernameAndPassword_WhenISubmitThem_ThenIShouldBeRegisteredSuccesfully()
        {
            User user = new User();
            HomePage.SignUp(user.Username, user.Password);
            Assert.IsTrue(HomePage.AlertMessageIs(Message.SignUpSuccessMessage));
        }

        [Test]
        [TestCase("test", "")]
        [TestCase("", "test")]
        [TestCase("", "")]
        public void GivenEmptyUsernameOrPassword_WhenISubmitThem_ThenIShouldSeeAnError(string username, string password)
        {
            HomePage.SignUp(username, password);
            Assert.IsTrue(HomePage.AlertMessageIs(Message.SignUpEmptyInputsErrorMessage));
        }
    }
}