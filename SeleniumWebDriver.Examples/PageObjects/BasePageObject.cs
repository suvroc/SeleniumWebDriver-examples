using OpenQA.Selenium;
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
        }

        public IWebDriver Driver { get; set; }
    }
}
