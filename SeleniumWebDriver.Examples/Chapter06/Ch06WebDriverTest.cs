using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriver.Examples.Chapter06
{
    [TestFixture]
    public class Ch06WebDriverTest
    {
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
