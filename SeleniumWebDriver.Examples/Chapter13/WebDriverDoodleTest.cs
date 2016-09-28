using System;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumWebDriver.Examples.Chapter11;
using SeleniumWebDriver.Examples.Chapter13.PageObjects;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumWebDriver.Examples.Chapter13
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

        [Test]
        public void ShouldCreateDoodlePageObject()
        {
            _driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var scheduleEventButton = _driver.FindElement(
                By.CssSelector("#doodleExample > div.wizardOrExample.spaceBBefore > a"));
            scheduleEventButton.Click();
            Assert.AreEqual(_driver.Url, "http://doodle.com/create");


            var nameScreenPageObject = new NameScreenPageObject(_driver);

            nameScreenPageObject.TitleInput
                .SendKeys("Diwebsity test doodle");
            nameScreenPageObject.YourNameInput
                .SendKeys("Diwebsity tester");
            nameScreenPageObject.EmailInput
                .SendKeys("seleniumTester@diwebsity.com");

            nameScreenPageObject.NextButton
                .Click();

            var dateId = "#cell" + DateTime.Now.ToString("yyyyMMdd");
            var waitDriver = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            waitDriver.Until(
                ExpectedConditions.ElementToBeClickable(By.CssSelector(dateId)));
            _driver.FindElement(By.CssSelector(dateId))
                .Click();
            _driver.FindElement(By.Id("next2a"))
                .Click();

            _driver.FindElement(By.Id("do0_0"))
                .SendKeys("12:00");
            _driver.FindElement(By.Id("do0_1"))
                .SendKeys("13:00");
            _driver.FindElement(By.Id("do0_2"))
                .SendKeys("14:00");
            _driver.FindElement(By.Id("next2b"))
                .Click();

            waitDriver.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("next3s")));
            _driver.FindElement(By.Id("next3s"))
                .Click();

            waitDriver.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("finish4a")));
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("finish4a"))
                .Click();

            waitDriver.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("participationLink")));
            var surveyUrl =
                _driver.FindElement(By.Id("participationLink")).Text;
            _driver.Navigate().GoToUrl(surveyUrl);

            Assert.AreEqual(_driver.FindElement(By.Id("pollTitle")).Text,
                "Diwebsity test doodle");
        }

        [Test]
        public void ShouldCreateDoodlePageObjectFluent()
        {
            _driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var scheduleEventButton = _driver.FindElement(
                By.CssSelector("#doodleExample > div.wizardOrExample.spaceBBefore > a"));
            scheduleEventButton.Click();
            Assert.AreEqual(_driver.Url, "http://doodle.com/create");


            var nameScreenPageObject = new NameScreenAttrPageObject(_driver);

            nameScreenPageObject
                .Then(x => x.TitleInput.SendKeys("Diwebsity test doodle"))
                .Then(x => x.YourNameInput.SendKeys("Diwebsity tester"))
                .Then(x => x.EmailInput.SendKeys("seleniumTester@diwebsity.com"))
                .ClickButton(x => x.BackButton);
        }

        [Test]
        public void ShouldCreateDoodlePageObjectWithAttributes()
        {
            _driver.Navigate().GoToUrl("http://doodle.com/en_GB/");
            _driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));

            var scheduleEventButton = _driver.FindElement(
                By.CssSelector("#doodleExample > div.wizardOrExample.spaceBBefore > a"));
            scheduleEventButton.Click();
            Assert.AreEqual(_driver.Url, "http://doodle.com/create");


            var nameScreenPageObject = new NameScreenAttrPageObject(_driver);

            nameScreenPageObject
                .FillData("Diwebsity test doodle", "Diwebsity tester", "seleniumTester@diwebsity.com")
                .NextButton.Navigate();

            var dateId = "#cell" + DateTime.Now.ToString("yyyyMMdd");
            var waitDriver = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            waitDriver.Until(
                ExpectedConditions.ElementToBeClickable(By.CssSelector(dateId)));
            _driver.FindElement(By.CssSelector(dateId))
                .Click();
            _driver.FindElement(By.Id("next2a"))
                .Click();

            _driver.FindElement(By.Id("do0_0"))
                .SendKeys("12:00");
            _driver.FindElement(By.Id("do0_1"))
                .SendKeys("13:00");
            _driver.FindElement(By.Id("do0_2"))
                .SendKeys("14:00");
            _driver.FindElement(By.Id("next2b"))
                .Click();

            waitDriver.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("next3s")));
            _driver.FindElement(By.Id("next3s"))
                .Click();

            waitDriver.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("finish4a")));
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("finish4a"))
                .Click();

            waitDriver.Until(
                ExpectedConditions.ElementToBeClickable(By.Id("participationLink")));
            var surveyUrl =
                _driver.FindElement(By.Id("participationLink")).Text;
            _driver.Navigate().GoToUrl(surveyUrl);

            Assert.AreEqual(_driver.FindElement(By.Id("pollTitle")).Text,
                "Diwebsity test doodle");
        }
    }
}