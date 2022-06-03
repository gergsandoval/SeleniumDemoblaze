using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze.Elements
{
    public class PlaceOrderModal
    {
        private IWebElement _element;
        private By _priceLocator => By.Id("totalm");
        private By _nameInputLocator => By.Id("name");
        private By _countryInputLocator => By.Id("country");
        private By _cityInputLocator => By.Id("city");
        private By _cardInputLocator => By.Id("card");
        private By _monthInputLocator => By.Id("month");
        private By _yearInputLocator => By.Id("year");
        private By _purchaseButtonLocator => By.XPath("//button[text()='Purchase']");

        public PlaceOrderModal(IWebElement element)
        {
            _element = element;
        }

        public string GetPrice()
        {
            return _element.FindElement(_priceLocator).Text.Replace("Total:", String.Empty).Trim();
        }

        public void FillModalWith(string name, string country, string city, string card, string month, string year)
        {
            _element.FindElement(_nameInputLocator).SendKeys(name);
            _element.FindElement(_countryInputLocator).SendKeys(country);
            _element.FindElement(_cityInputLocator).SendKeys(city);
            _element.FindElement(_cardInputLocator).SendKeys(card);
            _element.FindElement(_monthInputLocator).SendKeys(month);
            _element.FindElement(_yearInputLocator).SendKeys(year);
        }

        public void ClickPurcharse()
        {
            _element.FindElement(_purchaseButtonLocator).Click();
        }

    }
}
