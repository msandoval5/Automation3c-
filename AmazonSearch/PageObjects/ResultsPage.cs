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
    class ResultsPage
    {
        SetUp setup = new SetUp();
        private SetUp driver;

        //WEB ELEMENTS
        [FindsBy(How = How.XPath, Using = "//img[@data-image-index='0']")]
        IWebElement FirstProduct;
        [FindsBy(How = How.XPath, Using = "//div[@data-index='0']//span[@data-a-size='l']//span[@class='a-price-whole']")]
        IWebElement FirstProductPrice;

        public string GetFirstProductPrice() 
        { 
            return FirstProductPrice.Text;
        }
        public void ClickFirstProduct()
        {
            try
            {
                driver.WaitForElementClickable(FirstProduct);
                FirstProduct.Click();
                Console.WriteLine("** First Item Selected **");

            }catch(Exception e)
            {
                Console.WriteLine("-- Failed: --", e.Message);
                driver.CleanUp();
            }
        }
    }
}
