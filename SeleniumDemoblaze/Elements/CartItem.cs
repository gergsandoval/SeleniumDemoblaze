using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze.Elements
{
    public class CartItem
    {
        private IWebElement _element;
        private By _nameLocator => By.CssSelector("td:nth-child(2)");
        private By _priceLocator => By.CssSelector("td:nth-child(3)");
        private By _deleteLinkLocator => By.TagName("a");
        public CartItem(IWebElement element)
        {
            _element = element;
        }
        public string GetName()
        {
            return _element.FindElement(_nameLocator).Text;
        }

        public string GetPrice()
        {
            return _element.FindElement(_priceLocator).Text;
        }

        public void ClickDelete()
        {
            _element.FindElement(_deleteLinkLocator).Click();
        }
    }
}
