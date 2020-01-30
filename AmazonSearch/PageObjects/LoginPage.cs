using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;
using SetUpBrowser;


namespace AmazonSearch
{

    class LoginPage
    {
        ConfigClass config = new ConfigClass();
        SetUp setup = new SetUp();
        private SetUp driver;

        //WEB ELEMENTS

        [FindsBy(How = How.Id, Using = "ap_email")]
        IWebElement EmailInput;
        [FindsBy(How = How.Id, Using = "ap_password")]
        IWebElement PasswordInput;
        [FindsBy(How = How.Id, Using = "singInSubmit")]
        IWebElement LoginButton;

        
        public void EnterEmail(String email)
        {
            try
            {
                driver.WaitForElementClickable(EmailInput);
                var usermail = config.GetKeys("Username");
                EmailInput.SendKeys(usermail);
                Console.WriteLine("** User Email Entered **");
            }
            catch(Exception e)
            {
                Console.WriteLine("-- Entering email failed --");
            }
        }

        public void EnterPassword(String pass)
        {
            try
            {
                driver.WaitForElementClickable(PasswordInput);
                var userpass = config.GetKeys("Password");
                PasswordInput.SendKeys("");
                Console.WriteLine("** User Password Entered **");
            }
            catch(Exception e)
            {
                Console.WriteLine("-- Entering password failed --");
            }
        }
        public void Submit()
        {
            try
            {
                driver.WaitForElementClickable(LoginButton);
                LoginButton.Click();
                Console.WriteLine("** Submitted **");

            }
            catch (Exception e)
            {
                Console.WriteLine("-- Submit failed --");

            }
        }
    }
}
