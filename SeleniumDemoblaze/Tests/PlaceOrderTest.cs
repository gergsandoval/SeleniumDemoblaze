using NUnit.Framework;
using SeleniumDemoblaze.Elements;
using SeleniumDemoblaze.Payload;
using SeleniumDemoblaze.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumDemoblaze.Tests
{
    public class PlaceOrderTest : BaseTest
    {
        [Test]
        [TestCase("Samsung galaxy s7", "5bde00fa-5db7-cf3f-be15-33f9d43d184f", 4)]
        public void GivenIAmLoggedInAndIHaveOneItemInTheCart_WhenIPlaceAnOrder_ThenIShouldSeeThatTheCartAndOrderPriceAreTheSame(string productName, string id, int productId)
        {
            string token = HomePage.QuickLogin();
            Item item = new Item(token, id, productId);
            AddToCartApiRequest.AddToCart(item);
            HomePage.ClickOnCart();
            string cartPrice = CartPage.GetCartPrice();
            CartPage.ClickOnPlaceOrder();
            PlaceOrderModal placeOrderModal = CartPage.GetPlaceOrderModal();
            string orderPrice = placeOrderModal.GetPrice();
            Assert.That(orderPrice, Is.EqualTo(cartPrice)); 
        }

        [Test]
        [TestCase("Sony vaio i5", "Carol", "Portugal", "Torroal", "4532 9723 5381 6068", "06", "2026")]
        public void GivenIAmLogged_WhenIBuyAProduct_ThenICanCompleteTheOrderProcess(string productName, string name, string country, string city, string creditCard, string month, string year)
        {
            HomePage.QuickLogin();
            HomePage.ClickOnProductOnTheFirstPage(productName);
            ProductPage.AddProductToTheCart();
            ProductPage.ClickOnCart();
            string amount = CartPage.GetCartPrice();
            CartPage.ClickOnPlaceOrder();
            PlaceOrderModal placeOrderModal = CartPage.GetPlaceOrderModal();
            placeOrderModal.FillModalWith(name, country, city, creditCard, month, year);
            placeOrderModal.ClickPurcharse();
            OrderConfirmationModal orderConfirmationModal = CartPage.GetOrderConfirmationModal();
            Assert.That(orderConfirmationModal.GetThankYouMessage(), Is.EqualTo(Message.ThankYouSuccessMessage));
            Assert.That(orderConfirmationModal.GetTextOf(Information.Amount), Is.EqualTo(amount));
            Assert.That(orderConfirmationModal.GetTextOf(Information.CardNumber), Is.EqualTo(creditCard));
            Assert.That(orderConfirmationModal.GetTextOf(Information.Name), Is.EqualTo(name));
            orderConfirmationModal.ClickOk();
            HomePage.ClickOnCart();
            Assert.True(CartPage.IsCartEmpty());
        }
    }

}
