using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriver.Examples.Chapter09
{
    public abstract class BaseTestCase
    {
        private IWebDriver _driver;

        protected IWebDriver Driver
        {
            get { return this._driver; }
        }

        [SetUp]
        public void Initalize()
        {
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver = null;
        }
    }
}
