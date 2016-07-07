using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriver.Examples.Chapter09
{
    public abstract class BaseTestCasePersistent
    {
        private IWebDriver _driver;
        private IWebDriver _chromeDriver;

        protected IWebDriver Driver
        {
            get { return this._driver; }
        }

        [OneTimeSetUp]
        public void Initalize()
        {
            _chromeDriver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            _chromeDriver.Manage().Cookies
                .DeleteAllCookies();
        }
    }
}
