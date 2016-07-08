using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriver.Examples.Chapter09
{
    public abstract class BaseTestCaseWithDatabase
    {
        protected IWebDriver Driver { get; private set; }

        [SetUp]
        public void Initalize()
        {
            Driver = new ChromeDriver();
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
            Driver.Quit();
            Driver = null;
            DbManager.Instance.RestoreSnapshot();
        }
    }
}