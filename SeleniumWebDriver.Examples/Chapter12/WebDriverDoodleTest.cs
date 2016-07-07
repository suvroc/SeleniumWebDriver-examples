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

namespace SeleniumWebDriver.Chapter12
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
        public void ShouldCreateDoodle()
        {
            _driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var scheduleEventButton = _driver.FindElement(
                By.CssSelector("#doodleExample > div.wizardOrExample.spaceBBefore > a"));
            scheduleEventButton.Click();
            Assert.AreEqual(_driver.Url, "http://doodle.com/create");


            _driver.FindElement(By.Id("title"))
                .SendKeys("Diwebsity test doodle");
            _driver.FindElement(By.Id("initiatorAlias"))
                .SendKeys("Diwebsity tester");
            _driver.FindElement(By.Id("initiatorEmail"))
                .SendKeys("seleniumTester@diwebsity.com");

            _driver.FindElement(By.Id("next1"))
                .Click();

            var dateId = "cell" + DateTime.Now.ToString("yyyyMMdd") + " > div > div > button";
            var waitDriver = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            waitDriver.Until(
                ExpectedConditions.ElementToBeClickable(By.Id(dateId)));
            _driver.FindElement(By.Id(dateId))
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
                _driver.FindElement(By.Id("participtionLink")).Text;
            _driver.Navigate().GoToUrl(surveyUrl);

            Assert.AreEqual(_driver.FindElement(By.Id("pollTitle")).Text,
                "Diwebsity test doodle");
        }
    }
}
