using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze.Elements
{
    public class OrderConfirmationModal
    {
        private IWebElement _element;
        private By _thankYouMessageLocator => By.TagName("h2");
        private By _informationLocator => By.TagName("p");
        private By _okButtonLocator => By.ClassName("confirm");

        public OrderConfirmationModal(IWebElement element)
        {
            _element = element;
        }

        public string GetThankYouMessage()
        {
            return _element.FindElement(_thankYouMessageLocator).Text;
        }

        public void ClickOk()
        {
            _element.FindElement(_okButtonLocator).Click();
        }

        public string GetTextOf(Information information)
        {
            string text = null;
            string[] informationPieces = _element.FindElement(_informationLocator).Text.Split("\r\n");
            switch (information)
            {
                case Information.Id:
                    text = informationPieces[0].Replace("Id:", String.Empty).Trim();
                    break;
                case Information.Amount:
                    text = informationPieces[1].Replace("Amount:", String.Empty).Replace("USD", String.Empty).Trim();
                    break;
                case Information.CardNumber:
                    text = informationPieces[2].Replace("Card Number:", String.Empty).Trim();
                    break;
                case Information.Name:
                    text = informationPieces[3].Replace("Name:", String.Empty).Trim();
                    break;
                case Information.Date:
                    text = informationPieces[4].Replace("Date:", String.Empty).Trim();
                    break;
            }
            return text;
        }
    }

    public enum Information
    {
        Id,
        Amount,
        CardNumber,
        Name,
        Date
    }
}
