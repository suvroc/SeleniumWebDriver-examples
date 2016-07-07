using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace SeleniumWebDriver.Examples.PageObjects
{
    public abstract class BasePageObject
    {
        public BasePageObject(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }

        public IWebDriver Driver { get; set; }


    }
}
