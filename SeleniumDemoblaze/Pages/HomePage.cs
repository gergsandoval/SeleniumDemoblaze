using OpenQA.Selenium;
using SeleniumDemoblaze.Elements;
using System;
using System.Collections.Generic;

namespace SeleniumDemoblaze.Pages
{
    public class HomePage : BasePage
    {
        private By _loginButtonLocator => By.Id("login2");
        private By _loginUsernameInputLocator => By.Id("loginusername");
        private By _loginPasswordInputLocator => By.Id("loginpassword");
        private By _loginSubmitButtonLocator => By.XPath("//button[text()='Log in']");

        private By _signUpButtonLocator => By.Id("signin2");
        private By _signUpUsernameInputLocator => By.Id("sign-username");
        private By _signUpPasswordInputLocator => By.Id("sign-password");
        private By _signUpSubmitButtonLocator => By.XPath("//button[text()='Sign up']");

        private By _welcomeMessageLocator => By.Id("nameofuser");

        private By _productContainerLocator => By.ClassName("card-block");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void Login(string username, string password)
        {
            ClickOn(_loginButtonLocator);
            typeOn(_loginUsernameInputLocator, username);
            typeOn(_loginPasswordInputLocator, password);
            ClickOn(_loginSubmitButtonLocator);
        }
        
        public void SignUp(string username, string password)
        {
            ClickOn(_signUpButtonLocator);
            typeOn(_signUpUsernameInputLocator, username);
            typeOn(_signUpPasswordInputLocator, password);
            ClickOn(_signUpSubmitButtonLocator);
        }

        public Boolean WelcomeMessageContains(string username)
        {
            var text = GetTextOf(_welcomeMessageLocator);
            return GetTextOf(_welcomeMessageLocator).Contains(username);
        }

        private ProductContainer FindProduct(string name)
        {
            IList<IWebElement> elements = GetElements(_productContainerLocator);
            int i = 0;
            ProductContainer productContainer = null;
            while (i < elements.Count && productContainer == null)
            {
                ProductContainer product = new ProductContainer(elements[i]);
                if (product.GetName().Equals(name))
                {
                    productContainer = product;
                }
                i++;
            }
            return productContainer;
        }

        public Boolean IsProductDisplayed(string name, string price, string description)
        {
            ProductContainer productContainer = FindProduct(name);
            return productContainer.GetPrice().Equals(price) && productContainer.GetDescription().Equals(description);
        }

        public void ClickOnProductOnTheFirstPage(string name)
        {
            ProductContainer productContainer = FindProduct(name);
            productContainer.ClickLink();
        }
    }
}
