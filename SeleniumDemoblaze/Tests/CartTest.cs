using NUnit.Framework;
using SeleniumDemoblaze.Elements;
using SeleniumDemoblaze.Payload;
using SeleniumDemoblaze.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze.Tests
{
    public class CartTest : BaseTest
    {
        
        [Test]
        [TestCase("Nexus 6")]
        public void GivenIAmLoggedIn_WhenIAddAProductToTheCart_ThenIShouldSeeTheProductInTheCart(string productName)
        {
            HomePage.QuickLogin();
            HomePage.ClickOnProductOnTheFirstPage(productName);
            ProductPage.AddProductToTheCart();
            ProductPage.AlertMessageIs(Message.AddToCartSuccessMessage);
            HomePage.ClickOnCart();
            CartItem cartItem = CartPage.FindItemInCart(productName);
            Assert.IsNotNull(cartItem);
        }

        [Test]
        [TestCase("Samsung galaxy s7", "5bde00fa-5db7-cf3f-be15-33f9d43d184f", 4)]
        public void GivenIAmLoggedInAndIHaveOneItemInTheCart_WhenIDeleteIt_ThenIShouldAnEmptyCart(string productName, string id, int productId)
        {
            string token = HomePage.QuickLogin();
            Item item = new Item(token, id, productId);
            AddToCartApiRequest.AddToCart(item);
            HomePage.ClickOnCart();
            CartItem cartItem = CartPage.FindItemInCart(productName);
            cartItem.ClickDelete();
            CartPage.WaitForCartItemsToDissapear();
            Assert.True(CartPage.IsCartEmpty());
        }

    }
}
