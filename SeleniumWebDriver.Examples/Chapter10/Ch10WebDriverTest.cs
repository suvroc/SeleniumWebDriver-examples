using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver.Examples.Chapter10
{
    [TestFixture]
    public class Ch10WebDriverTest
    {
        [Test]
        public void ShouldExplicitDynamicWait()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://getbootstrap.com/css/");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var myDynamicElement = wait.Until(d =>
            {
                return d.FindElement(By.TagName("button"));
            });

            driver.Quit();
        }

        [Test]
        public void ShouldExplicitWait()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://getbootstrap.com/css/");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementToBeClickable(
                By.TagName("button")));

            driver.Quit();
        }

        [Test]
        public void ShouldImplicitWait()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://getbootstrap.com/css/");

            driver.Manage().Timeouts()
                .ImplicitlyWait(TimeSpan.FromSeconds(10));

            driver.Quit();
        }

        [Test]
        public void ShouldSetTimeouts()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://getbootstrap.com/css/");

            driver.Manage().Timeouts()
                .SetScriptTimeout(TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts()
                .SetPageLoadTimeout(TimeSpan.FromSeconds(10));

            driver.Quit();
        }

        [Test]
        public void ShouldUseFindElementExtension()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var element = driver.FindElement(By.Id("searchInput"), 10);

            driver.Quit();
        }
    }
}