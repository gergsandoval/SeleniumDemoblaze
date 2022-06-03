
using OpenQA.Selenium;
using SeleniumDemoblaze.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze.Pages
{
    public class CartPage : BasePage
    {
        public CartPage(IWebDriver driver) : base(driver)
        {
        }

        private By _itemsInCartLocator => By.ClassName("success");

        private By _placeOrderButtonLocator => By.XPath("//button[@data-target='#orderModal']");

        private By _cartPriceLocator => By.Id("totalp");

        private By _placeOrderModalLocator => By.Id("orderModal");

        private By _orderConfirmationModalLocator => By.CssSelector("div.sweet-alert.showSweetAlert.visible");
        public CartItem FindItemInCart(string name)
        {
            IList<IWebElement> elements = GetElements(_itemsInCartLocator);
            int i = 0;
            CartItem cartItem = null;
            while (i < elements.Count && cartItem == null)
            {
                CartItem item = new CartItem(elements[i]);
                if (item.GetName().Equals(name))
                {
                    cartItem = item;
                }
                i++;
            }
            return cartItem;
        }

        public Boolean IsCartEmpty()
        {
            return !IsDisplayed(_itemsInCartLocator);
        }

        public void WaitForCartItemsToDissapear()
        {
            WaitForElementToDissapear(_itemsInCartLocator);
        }

        public void ClickOnPlaceOrder()
        {
            ClickOn(_placeOrderButtonLocator);
        }

        public string GetCartPrice()
        {
            return GetTextOf(_cartPriceLocator);
        }

        public PlaceOrderModal GetPlaceOrderModal()
        {
            IWebElement placeOrderElement = GetElement(_placeOrderModalLocator);
            return new PlaceOrderModal(placeOrderElement);
        }

        public OrderConfirmationModal GetOrderConfirmationModal()
        {
            IWebElement orderConfirmationElement = GetElement(_orderConfirmationModalLocator);
            return new OrderConfirmationModal(orderConfirmationElement);
        }
    }


}
