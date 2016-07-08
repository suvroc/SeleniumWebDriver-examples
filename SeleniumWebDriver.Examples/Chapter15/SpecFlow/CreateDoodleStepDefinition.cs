using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriver.Examples.Chapter13.PageObjects;
using TechTalk.SpecFlow;

namespace SeleniumWebDriver.Examples.Chapter15.SpecFlow
{
    [Binding]
    public sealed class CreateDoodleStepDefinitions
    {
        private IWebDriver _driver;
        private NameScreenPageObject _nameScreenPageObject;

        [BeforeScenario]
        public void BeforeTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
        }

        [AfterScenario]
        public void AfterTest()
        {
            _driver.Quit();
        }

        [Given(@"Main page is opened")]
        public void GivenMainPageIsOpened()
        {
            _driver.Navigate().GoToUrl("http://doodle.com/en_GB/");
            var scheduleEventButton = _driver.FindElement(
                By.CssSelector("#doodleExample > div.wizardOrExample.spaceBBefore > a"));
            scheduleEventButton.Click();
            Assert.AreEqual(_driver.Url, "http://doodle.com/create");
            _nameScreenPageObject = new NameScreenPageObject(_driver);
        }

        [Given(@"I have entered title ""(.*)""")]
        public void GivenIHaveEnteredTitleDiwebsityTestDoodle(string title)
        {
            _nameScreenPageObject.TitleInput.SendKeys(title);
        }

        [Given(@"I have entered name ""(.*)""")]
        public void GivenIHaveEnteredName(string name)
        {
            _nameScreenPageObject.YourNameInput.SendKeys(name);
        }

        [Given(@"I have entered email ""(.*)""")]
        public void GivenIHaveEnteredEmail(string email)
        {
            _nameScreenPageObject.EmailInput.SendKeys(email);
        }

        [When(@"I press next button")]
        public void WhenIPressNextButton()
        {
            _nameScreenPageObject.NextButton.Click();
        }

        [Then(@"the current url should ends with ""(.*)""")]
        public void ThenTheCurrentUrlShouldEndsWithCreateDates(string urlSuffix)
        {
            Assert.IsTrue(_driver.Url.EndsWith(urlSuffix));
        }
    }
}

