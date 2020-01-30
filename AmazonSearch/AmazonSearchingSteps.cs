using System;
using TechTalk.SpecFlow;
using SetUpBrowser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AmazonSearch
{
    [Binding]
    public class AmazonSearchingSteps
    {
        SetUp setup = new SetUp();
        private SetUp driver;
        private HomePage homePage;
        private LoginPage loginPage;
        private ProductDetailPage productDetailPage;
        private ResultsPage resultsPage;
        string firstPrice;
        string cartPrice;
        string cartItems;

        [Given(@"I go to amazon")]
        public void GivenIGoToAmazon()
        {
            setup.SetUpBrowser("Chrome");
        }
        
        [Given(@"I login with my ""(.*)"" and ""(.*)""")]
        public void GivenILoginWithMyAnd(string usermail, string password)
        {
            homePage.Login();
            loginPage.EnterEmail("Username");
            loginPage.EnterPassword("Password");
        }
          [Then(@"I Search for product: ""(.*)""")]
        public void ThenISearchForProduct(string item)
        {
            item = "Samsung Galaxy S9 64GB";
            homePage.SearchProduct(item);
        } 

         [Then(@"I Select first product and validate first price vs detail price")]
        public void ThenISelectFirstProductAndValidateFirstPriceVsDetailPrice()
        {
            firstPrice = resultsPage.GetFirstProductPrice();
            resultsPage.ClickFirstProduct();
            var detailPrice = productDetailPage.GetPrice();
        }
        
        [When(@"I click on Add to Cart")]
        public void WhenIClickOnAddToCart()
        {
            productDetailPage.AddToCart();
        }

       [When(@"Validate first price vs current price And validate Shop car has (.*) item")]
        public void WhenValidateFirstPriceVsCurrentPriceAndValidateShopCarHasItem(int uno) 
        {
            cartPrice = homePage.GetPrices();
            cartItems = homePage.CartItems();
            int cartCount = Int32.Parse(cartItems);
            //PENDING ASSERTIONS
            Assert.AreEqual(cartCount, 1);
            Assert.AreEqual(cartPrice, firstPrice);

        }

       [Then(@"I Search for second product: ""(.*)""")]
       public void ThenISearchForSecondProduct(string secondProduct)
       {
            homePage.SearchProduct(secondProduct);
       }

        [Then(@"Select first product")]
        public void ThenSelectFirstProduct()
        {
            resultsPage.ClickFirstProduct();
        }
        
        [Then(@"I add second product to the cart And verify cart has two items")]
        public void ThenIAddSecondProductToTheCartAndVerifyCartHasTwoItems()
        {
            productDetailPage.AddToCart();
            cartItems = homePage.CartItems();
            //Pending assertions
            Assert.AreEqual(cartItems, 2);
        }
    }
}
