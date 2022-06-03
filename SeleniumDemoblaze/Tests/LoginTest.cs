using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumDemoblaze.Pages;
using SeleniumDemoblaze.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze.Tests
{
    public class LoginTest : BaseTest
    {

        [Test]
        [TestCase("test", "test")]
        public void GivenAUserThatAlreadyExists_WhenILogin_ThenIShouldSeeMyUserAtTheBanner(string username, string password)
        { 
            HomePage.Login(username, password);
            Assert.True(HomePage.WelcomeMessageContains(username));
        }

        [Test]
        [TestCase("test", "")]
        [TestCase("", "test")]
        [TestCase("", "")]
        public void GivenEmptyUsernameOrPassword_WhenILogin_ThenIShouldSeeAnError(string username, string password)
        {
            HomePage.SignUp(username, password);
            Assert.IsTrue(HomePage.AlertMessageIs(Message.LoginEmptyInputsErrorMessage));
        }
    }
}
