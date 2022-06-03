using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumDemoblaze.Pages;

namespace SeleniumDemoblaze.Tests
{
    public class BaseTest
    {
        protected IWebDriver Driver;
        protected HomePage HomePage;
        protected ProductPage ProductPage;
        protected CartPage CartPage;

        [SetUp]
        public void Setup()
        {
            Driver = SeleniumDemoblaze.Driver.getDriver();
            HomePage = new HomePage(Driver);
            ProductPage = new ProductPage(Driver); 
            CartPage = new CartPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
