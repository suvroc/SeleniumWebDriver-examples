using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.IE;
using System;
using System.Threading;

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
    }
}
