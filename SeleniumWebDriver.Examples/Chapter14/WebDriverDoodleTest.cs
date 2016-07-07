using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework.Interfaces;
using SeleniumWebDriver.Examples.PageObjects;
using System.Collections;
using OpenQA.Selenium.Support.Extensions;
using SeleniumWebDriver.Examples.Chapter11;

namespace SeleniumWebDriver.Examples.Chapter14
{
    [TestFixture]
    public class WebDriverDoodleTest
    {
        private IWebDriver _driver;

        [SetUp]
        public void Initalize()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void TearDown()
        {
            var state = TestContext.CurrentContext.Result.Outcome;
            if (state == ResultState.Error || state == ResultState.Failure)
            {
                _driver.TakeScreenshot(TestContext.CurrentContext.Test.FullName);
            }

            _driver.Quit();
        }

        [Test]
        [TestCase("Diwebsity test doodle", "Diwebsity tester", "seleniumTester@diwebsity.com", true)]
        [TestCase("Another title", "Another name", "Another_email@mail.comm", true)]
        [TestCase("Another title", "Another name", "wrong email", false)]
        public void ShouldCreateDoodleWithTestCase(
            string title, string name, string email, bool goToNextPage)
        {
            _driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var scheduleEventButton = _driver.FindElement(
                By.CssSelector("#doodleExample > div.wizardOrExample.spaceBBefore > a"));
            scheduleEventButton.Click();
            Assert.AreEqual(_driver.Url, "http://doodle.com/create");

            var nameScreenPageObject = new NameScreenAttrPageObject(_driver);

            nameScreenPageObject
                .FillData(title,
                name,
                email)
                .NextButton.Navigate();

            if (goToNextPage)
            {
                Assert.IsTrue(_driver.Url.EndsWith("/create#dates"));
            } else
            {
                Assert.IsTrue(_driver.Url.EndsWith("/create#"));
            }
        }

        [Test]
        [TestCaseSource("TestCases")]
        public string ShouldCreateDoodleWithTestCaseSource(
            string title, string name, string email, bool goToNextPage)
        {
            _driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var scheduleEventButton = _driver.FindElement(
                By.CssSelector("#doodleExample > div.wizardOrExample.spaceBBefore > a"));
            scheduleEventButton.Click();
            Assert.AreEqual(_driver.Url, "http://doodle.com/create");

            var nameScreenPageObject = new NameScreenAttrPageObject(_driver);

            nameScreenPageObject
                .FillData(title,
                name,
                email)
                .NextButton.Navigate();

            return _driver.Url.Substring(_driver.Url.LastIndexOf('/')); 

        }

        public IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(
                    "Diwebsity test doodle", "Diwebsity tester", 
                    "seleniumTester@diwebsity.com")
                    .Returns("/create#dates");
                yield return new TestCaseData(
                    "Another title", "Another name", 
                    "Another_email@mail.comm")
                    .Returns("/create#dates");
                yield return new TestCaseData(
                    "Another title", "Another name", 
                    "wrong email")
                    .Returns("/create#");
            }
        }
    }
}
