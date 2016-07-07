using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver.Examples.BaseClasses
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

        [TestFixtureSetUp]
        public void SetUpFixture()
        {
            DbManager.Instance.CreateSnapshot();
        }

        [TestFixtureTearDown]
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
