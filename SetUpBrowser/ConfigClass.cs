using System;
using System.Collections.Generic;
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
    public class ConfigClass
    {
        //I have a question here: Since we are using configuration manager here, do we need to create a "from scratch method" or only use the app settings property?

        public String GetKeys(String Key)
        {
            var MyKey = ConfigurationManager.AppSettings[Key];
            return MyKey;
        }

    }
}
