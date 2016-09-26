using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SeleniumWebDriver.Examples.Chapter08
{
    [TestFixture]
    public class Ch08WebDriverTest
    {
        [Test]
        public void ShouldCheckElementProperties()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var element = driver.FindElement(By.Id("createExample"));

            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            Assert.IsTrue(!element.Selected);
            Assert.IsTrue(element.Text == "View example");
            Assert.IsTrue(element.Location.X > 0);
            Assert.IsTrue(element.Location.Y > 0);
            Assert.IsTrue(element.Size.Height > 0);
            Assert.IsTrue(element.Size.Width > 0);
            Assert.IsTrue(element.TagName == "button");
            Assert.IsTrue(element.GetAttribute("type") == "submit");

            driver.Quit();
        }

        [Test]
        public void ShouldClickOnlyIfPossibe()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var sourceInput = driver.FindElement(By.PartialLinkText("Contents"));

            if (sourceInput.Displayed && sourceInput.Enabled)
            {
                sourceInput.Click();
            }

            driver.Quit();
        }

        [Test]
        public void ShouldContextClick()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var element = driver.FindElement(By.Id("searchInput"));

            var action = new Actions(driver);
            action.ContextClick(element)
                .SendKeys(Keys.ArrowUp)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();

            driver.Quit();
        }

        [Test]
        public void ShouldCopyShortcut()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var element = driver.FindElement(By.Id("searchInput"));

            var action = new Actions(driver);
            var saveShortcut = action.ContextClick(element)
                .KeyDown(Keys.Control)
                .SendKeys("C")
                .Build();

            saveShortcut.Perform();
            saveShortcut.Perform();

            driver.Quit();
        }

        [Test]
        public void ShouldFindText()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var source = driver.FindElement(By.Id("mp-left"));

            var text = source.Text;

            driver.Quit();
        }

        [Test]
        public void ShouldSaveShortcut()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var element = driver.FindElement(By.Id("searchInput"));

            var action = new Actions(driver);
            var saveShortcut = action.ContextClick(element)
                .KeyDown(Keys.Control)
                .SendKeys("S")
                .Build();

            saveShortcut.Perform();

            driver.Quit();
        }

        [Test]
        public void ShouldSearchAndEnter()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var element = driver.FindElement(By.Id("searchInput"));

            element.SendKeys("cat");
            element.SendKeys(Keys.Enter);

            driver.Quit();
        }

        [Test]
        public void ShouldSelectItem()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://getbootstrap.com/css/");

            var element = driver.FindElement(By.TagName("select"));

            var selectElement = new SelectElement(element);

            selectElement.SelectByText("2");
            //selectElement.SelectByValue("2"); // this example select hasn't value defined
            selectElement.SelectByIndex(2);

            selectElement.SelectByIndex(4);

            driver.Quit();
        }

        [Test]
        public void ShouldSelectItemManually()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://getbootstrap.com/css/");

            var select = driver.FindElement(By.TagName("select"));

            var options = select.FindElements(By.TagName("option"));
            foreach (var option in options)
            {
                if (option.Text == "2")
                    option.Click();
            }

            driver.Quit();
        }

        [Test]
        public void ShouldTouch()
        {

            //Dictionary<String, String> mobileEmulation = new Dictionary<String, String>();
            //mobileEmulation.Add("deviceName", "Nexus 5");
            ChromeOptions chromeCapabilities = new ChromeOptions();
            chromeCapabilities.EnableMobileEmulation("Google Nexus 5");
            var driver = new ChromeDriver(chromeCapabilities); 

            IHasTouchScreen touchScreenDriver = driver as IHasTouchScreen;

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var element = driver.FindElement(By.Id("searchInput"));

            var touchActions = new TouchActions(driver);
            touchActions.SingleTap(element)
                .Perform();

            driver.Quit();
        }

        [Test]
        public void ShouldUploadFile()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://postimage.org/");

            var element = driver.FindElement(By.Id("file_upload"));

            element.SendKeys(TestContext.CurrentContext.TestDirectory + "\\TestFiles\\TestFile.png");

            driver.FindElement(By.Id("l_adult_no")).Click();

            driver.FindElement(By.Id("btSubmit")).Click();

            driver.Quit();
        }
    }
}