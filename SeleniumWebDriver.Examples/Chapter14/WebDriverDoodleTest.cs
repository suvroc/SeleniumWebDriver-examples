using System;
using System.Collections;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriver.Examples.Chapter11;
using SeleniumWebDriver.Examples.Chapter13.PageObjects;
using System.Threading;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver.Examples.Chapter14
{
    [TestFixture]
    public class WebDriverDoodleTest
    {
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

        private IWebDriver _driver;

        public static IEnumerable TestCases
        {
            get
            {
                yield return new TestCaseData(
                    "Diwebsity test doodle", "Diwebsity tester",
                    "seleniumTester@diwebsity.com", true)
                    .Returns("/create#dates");
                yield return new TestCaseData(
                    "Another title", "Another name",
                    "Another_email@supermail.com", true)
                    .Returns("/create#dates");
                yield return new TestCaseData(
                    "Another title", "Another name",
                    "wrong email", false)
                    .Returns("/create#general");
            }
        }

        [Test]
        [TestCase("Diwebsity test doodle", "Diwebsity tester", "seleniumTester@diwebsity.com", true)]
        [TestCase("Another title", "Another name", "Another_email@supermail.com", true)]
        [TestCase("Another title", "Another name", "wrong email", false)]
        public void ShouldCreateDoodleWithTestCase(
            string title, string name, string email, bool goToNextPage)
        {
            _driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var scheduleEventButton = _driver.FindElement(
                By.CssSelector("#doodleExample > div.wizardOrExample.spaceBBefore > a"));
            scheduleEventButton.Click();
            Assert.AreEqual(_driver.Url, "http://doodle.com/create");

            var nameScreenPageObject = new NameScreenPageObject(_driver);

            nameScreenPageObject
                .FillData(title,
                    name,
                    email)
                .NextButtonObject.Navigate();

            Thread.Sleep(1000);

            if (goToNextPage)
            {
                Assert.IsTrue(_driver.Url.EndsWith("/create#dates"));
            }
            else
            {
                Assert.IsTrue(_driver.Url.EndsWith("/create#general"));
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

            var nameScreenPageObject = new NameScreenPageObject(_driver);

            nameScreenPageObject
                .FillData(title,
                    name,
                    email)
                .NextButtonObject.Navigate();

            Thread.Sleep(1000);
            var aaa = _driver.Url;

            return _driver.Url.Substring(_driver.Url.LastIndexOf('/'));
        }
    }
}