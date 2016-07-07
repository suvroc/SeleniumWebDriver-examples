using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumWebDriver.Examples.Chapter11
{
    [TestFixture]
    public class Ch11WebDriverTest : BaseScreenshotTestCase
    {
        [Test]
        public void ShouldThrowException()
        {
            var driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");
                // ...
                throw new NotFoundException("Test error");
            }
            catch (Exception ex)
            {
                driver.TakeScreenshot("ShouldThrowException");
                throw;
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
