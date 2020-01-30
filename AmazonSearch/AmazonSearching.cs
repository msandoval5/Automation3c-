using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using System;
using SeleniumExtras.PageObjects;
using SetUpBrowser;

namespace AmazonSearch
{
    [TestClass]
    public class AmazonSearching
    {

        SetUp setup = new SetUp();
        HomePage homepage = new HomePage();
        ResultsPage resultpage = new ResultsPage();
        ProductDetailPage productpage = new ProductDetailPage();
        LoginPage loginpage = new LoginPage();
        string firstPrice;
        string cartPrice;
        string cartItems;


        [TestInitialize]
        public void SetUp()
        {
            setup.SetUpBrowser("Chrome");
        }

        [TestMethod]
        public void GoToAmazon()
        {
            setup.SetUpBrowser("Chrome");
        }
        public void LogIn()
        {
            //var homepage = new HomePage();
            homepage.Login();

        }
        public void SearchForProduct()
        {
            homepage.SearchProduct("Samsung Galaxy S9 64GB");

        }
        public void SelecFirstProduct()
        {
            resultpage.ClickFirstProduct();
            firstPrice = resultpage.GetFirstProductPrice();
            resultpage.ClickFirstProduct();
            var detailPrice = productpage.GetPrice();
        }
        public void AddToCart()
        {
            productpage.AddToCart();
            cartPrice = homepage.GetPrices();
            cartItems = homepage.CartItems();
            int cartCount = Int32.Parse(cartItems);
            Assert.AreEqual(cartCount, 1);
            Assert.AreEqual(cartPrice, firstPrice);
        }
        public void SearchSecondProduct()
        {
            homepage.SearchProduct("Alienware Aw3418DW");
        }
        public void AddProductToCart()
        {
            productpage.AddToCart();
            productpage.AddToCart();
            cartItems = homepage.CartItems();
            //Pending assertions
            Assert.AreEqual(cartItems, 2);

        }


    }
    
}
