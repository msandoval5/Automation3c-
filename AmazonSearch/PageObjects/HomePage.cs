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
    class HomePage
    {
        private SetUp driver;
        WebDriverWait wait;
        SetUp setup = new SetUp();
        

        //public HomePage(String Browser)
        //{
        //    driver = new SetUp();

        //}

        public HomePage()
        {
        }

        //WEB ELEMENTS
        //Search elements
        [FindsBy(How = How.Id, Using = "twotabsearchtextbox")]
         IWebElement SearchInput;
        [FindsBy(How = How.Id, Using = "nav-search-submit-text")]
        private IWebElement SearchButton;
        //Go to sign in element
        [FindsBy(How = How.Id, Using = "nav-link-accountList")]
        private IWebElement GoToLoginLink;
        //Check shopping cart element
        [FindsBy(How = How.XPath, Using = "//span[@class='a-color-price hlb-price a-inline-block a-text-bold']")]
        private IWebElement CartPriceLabel;
        [FindsBy(How = How.Id, Using = "nav-cart-count")]
        private IWebElement CartItemsLabel;
        public void SearchProduct(String item)
        {
            try
            {

                driver.WaitForElementClickable(SearchInput);
                SearchInput.SendKeys(item);
                Console.WriteLine("** Item Entered  **");
                SearchButton.Click();
                Console.WriteLine("** Submited  **");

            }
            catch (Exception e)
            {
                Console.WriteLine("No se pudo...");
                driver.CleanUp();
            }

        }
        public void Login()
        {
            try
            {
                driver.WaitForElementClickable(GoToLoginLink);
                GoToLoginLink.Click();
                Console.WriteLine("** Going to Log in page **");
            }
            catch(Exception e)
            {
                Console.WriteLine("No se pudo...");
                driver.CleanUp();
            }

        }

        //CART METHODS

        public string GetPrices()
        {
            return CartPriceLabel.Text;
        }

        public string CartItems()
        {
            return CartItemsLabel.Text;
        }
    }
}
