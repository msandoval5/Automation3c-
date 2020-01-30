using System;
using System.Configuration;
using System.Security.Policy;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;


namespace SetUpBrowser
{
    public class SetUp
    {
        public IWebDriver driver;
       // private Config conf;

        public IWebDriver DriverD => driver;

        public void SetUpBrowser(string Browser)
        {

            switch (Browser)
            {
                case "Chrome":
                default:
                    driver = new ChromeDriver(@"C:\Users\mariana.sandoval\source\repos\AmazonSearch\AmazonSearch\bin\Debug");
                    Console.WriteLine("** Browser Selected **");
                    driver.Manage().Window.Maximize();
                    driver.Url = ConfigurationManager.AppSettings["Url"];
                    Console.WriteLine("** URL entered **");
                    break;

                case "FireFox":
                    driver = new FirefoxDriver(@"C:\Users\mariana.sandoval\source\repos\AmazonSearch\AmazonSearch\bin\Debug");
                    driver.Manage().Window.Maximize();
                    break;
            }

            return;
        }
        public void WaitForElementClickable(IWebElement element)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(element));

        }
        public void CleanUp() => driver.Quit();

    }

    
}
