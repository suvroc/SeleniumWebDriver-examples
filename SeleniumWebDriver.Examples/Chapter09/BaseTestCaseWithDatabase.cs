using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriver.Examples.Helpers;

namespace SeleniumWebDriver.Examples.Chapter09
{
    public abstract class BaseTestCaseWithDatabase
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

        [OneTimeSetUp]
        public void SetUpFixture()
        {
            DbManager.Instance.CreateSnapshot();
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            DbManager.Instance.DropSnapshot();
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Quit();
            _driver = null;
            DbManager.Instance.RestoreSnapshot();
        }
    }
}
