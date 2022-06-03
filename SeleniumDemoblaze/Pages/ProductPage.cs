using OpenQA.Selenium;
using System;

namespace SeleniumDemoblaze.Pages
{
    public class ProductPage : BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver)
        {
        }
        private By _nameLocator => By.ClassName("name");
        private By _priceLocator => By.ClassName("price-container");
        private By _descriptionLocator => By.CssSelector("#more-information > p");
        private By _addToCartButtonLocator => By.XPath("//a[text()='Add to cart']");

        public Boolean ProductHasTheFollowingDetails(string productName, string price, string description)
        {
            return GetTextOf(_nameLocator).Equals(productName) &&
                   GetTextOf(_priceLocator).Replace("*includes tax", String.Empty).Trim().Equals(price) &&
                   GetTextOf(_descriptionLocator).Equals(description);   
        }

        public void AddProductToTheCart()
        {
            ClickOn(_addToCartButtonLocator);
        }
    }
}
