using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using SetUpBrowser;

namespace AmazonSearch
{
    class ProductDetailPage
    {
        SetUp setup = new SetUp();
        private SetUp driver;

        //WEB ELEMENTS
        [FindsBy(How =How.Id, Using ="price_inside_buybox")]
        IWebElement PriceLabel;
        [FindsBy(How = How.Id, Using = "add-to-cart-button")]
        IWebElement AddToCartButton;

        public String GetPrice() 
        {
            return PriceLabel.Text;
        }
        public void AddToCart()
        {
            try
            {
                driver.WaitForElementClickable(AddToCartButton);
                AddToCartButton.Click();
                Console.WriteLine("**Item added to the cart**");

            }
            catch(Exception e)
            {
                Console.WriteLine("--Failed: ", e.Message);
                driver.CleanUp();
            }
        }

    }
}
