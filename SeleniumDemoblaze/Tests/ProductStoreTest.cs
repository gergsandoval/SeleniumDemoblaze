using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumDemoblaze.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze.Tests
{
    public class ProductStoreTest : BaseTest
    {
        [SetUp]
        public void ProductStoreSetup()
        {
            HomePage.QuickLogin();
        }

        [Test]
        [TestCase("Samsung galaxy s6",
                  "$360",
                  "The Samsung Galaxy S6 is powered by 1.5GHz octa-core Samsung Exynos 7420 processor and it comes with 3GB of RAM. The phone packs 32GB of internal storage cannot be expanded.")]
        public void GivenIAmLoggedIn_whenIVisitTheHomePage_thenISeeTheFollowingProduct(string productName, string price, string description)
        {
            Assert.True(HomePage.IsProductDisplayed(productName, price, description));
        }

        [Test]
        [TestCase("Nokia lumia 1520",
                  "$820",
                  "The Nokia Lumia 1520 is powered by 2.2GHz quad-core Qualcomm Snapdragon 800 processor and it comes with 2GB of RAM.")]
        public void GivenIAmLoggedIn_WhenIVisitTheProductPage_ThenISeeTheFollowingDetails(string productName, string price, string description)
        {
            HomePage.ClickOnProductOnTheFirstPage(productName);
            Assert.True(ProductPage.ProductHasTheFollowingDetails(productName, price, description)); 
        }
    }
}
