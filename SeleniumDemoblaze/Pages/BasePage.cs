using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumDemoblaze.Elements;
using SeleniumDemoblaze.Payload;
using SeleniumDemoblaze.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace SeleniumDemoblaze.Pages
{
    public class BasePage
    {
        private IWebDriver _driver;
        private By _cartLinkLocator => By.Id("cartur");
        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }
    
        public void ClickOn(By locator)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configuration.Timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            _driver.FindElement(locator).Click();
        }

        public Boolean IsDisplayed(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configuration.Timeout));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            } 
            catch(Exception e)
            {
                return false; 
            }
            return _driver.FindElement(locator).Displayed;
        }
        public string GetTextOf(By locator)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configuration.Timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            string text = _driver.FindElement(locator).Text;
            return Regex.Replace(text, @"\s+", " ").Trim();
        }

        public void typeOn(By locator, string text)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configuration.Timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            IWebElement element = _driver.FindElement(locator);
            element.Clear();
            element.SendKeys(text);
        }

        public Boolean AlertMessageIs(string expectedMessage)
        {
            IAlert alert = WaitForAlert();
            string textAlert = alert.Text;
            AcceptAlert();
            return textAlert.Equals(expectedMessage);
        }

        private IAlert WaitForAlert()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configuration.Timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
            return _driver.SwitchTo().Alert();
        }

        public void AcceptAlert()
        {
            IAlert alert = WaitForAlert();
            alert.Accept();
        }

        private string CreateRandomUserAndGetToken()
        {
            User user = new User();
            SignUpApiRequest.SignUpUser(user);
            return LoginApiRequest.LoginUser(user);
        }
        public string QuickLogin()
        {
            var token = CreateRandomUserAndGetToken();
            Cookie cookie = new Cookie(Configuration.TokenCookieKey, token);
            _driver.Manage().Cookies.AddCookie(cookie);
            _driver.Navigate().Refresh();
            return token;
        }

        public IList<IWebElement> GetElements(By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configuration.Timeout));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
            } 
            catch (Exception e)
            {
                return new List<IWebElement>();
            }
            return _driver.FindElements(locator);
        }

        public void WaitForElementToDissapear(By locator)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configuration.Timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public IWebElement GetElement(By locator)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(Configuration.Timeout));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            return _driver.FindElement(locator);
        }

        public void ClickOnCart()
        {
            ClickOn(_cartLinkLocator);
        }
    }
}
