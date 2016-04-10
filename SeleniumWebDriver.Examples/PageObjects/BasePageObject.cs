using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver.Examples.PageObjects
{
    public abstract class BasePageObject
    {
        public BasePageObject(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(Driver, this);
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
            
        }

        public IWebDriver Driver { get; set; }
    }
}
