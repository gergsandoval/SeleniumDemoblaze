using OpenQA.Selenium;
using SeleniumDemoblaze.Pages;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace SeleniumDemoblaze.Elements
{
    public class ProductContainer
    {
        private IWebElement _element;
        private By _linkLocator => By.TagName("a");
        private By _priceLocator => By.TagName("h5");
        private By _descriptionLocator => By.Id("article");
        private By _nameLocator => By.CssSelector("h4 > a");
        public ProductContainer(IWebElement element)
        {
            _element = element;
        }
        public string GetName()
        {
            return _element.FindElement(_nameLocator).Text;
        }
        public void ClickLink()
        {
            _element.FindElement(_linkLocator).Click();
        }
        public string GetPrice()
        {
            return _element.FindElement(_priceLocator).Text;
        }
        public string GetDescription()
        {
            string description = _element.FindElement(_descriptionLocator).Text;
            return Regex.Replace(description, @"\s+", " ").Trim();
        }
    }
}
