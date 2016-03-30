using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.IE;
using System;
using System.Threading;
using System.Linq;
using SeleniumWebDriver.Examples.Helpers;

namespace SeleniumWebDriver.Examples
{
    [TestFixture]
    public class BasicWebDriverTest
    {
        [Test]
        public void ShouldTranslateWord()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://translate.google.com/#en/pl");

            var sourceInput = driver.FindElement(By.Id("source"));

            sourceInput.SendKeys("cat");
            sourceInput.SendKeys(Keys.Enter);

            Thread.Sleep(500);

            var resultInput = driver.FindElement(By.Id("result_box"));

            Assert.AreEqual(resultInput.Text, "kot");

            driver.Quit();
        }

        [Test]
        public void ShouldNavigate()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var sourceInput = driver.FindElement(By.PartialLinkText("Contents"));

            sourceInput.Click();

            Thread.Sleep(500);

            driver.Navigate().Back();

            Assert.IsTrue(driver.Title.Contains("Wikipedia"));

            driver.Quit();
        }

        [Test]
        public void ShouldSelectHousesList()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://commons.wikimedia.org/wiki/Category:Houses");

            var houseTile = driver.FindElement(By.ClassName("gallerybox"));

            var link = houseTile.FindElement(By.CssSelector(".gallerytext > a"));

            link.Click();

            driver.Quit();
        }

        [Test]
        public void ShouldSelectHousesListItems()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://commons.wikimedia.org/wiki/Category:Houses");

            var houseTiles = driver.FindElements(By.ClassName("gallerybox"))
                .Select(x => new ListItem(
                    x.FindElement(By.CssSelector(".gallerytext > a")).Text, x));

            var houseTile = houseTiles.Single(x => x.Name == "Buiding.jpg");

            var link = houseTile.Element
                .FindElement(By.ClassName("thumb"));

            link.Click();

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
    }
}
