using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumDemoblaze.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze
{
    public class Driver
    {
        private static IWebDriver _driver;
        public static IWebDriver getDriver()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(Configuration.Timeout);
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(Configuration.BaseUrl);
            return _driver;
        }

    }
}
