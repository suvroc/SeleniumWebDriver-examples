using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing.Imaging;

namespace SeleniumWebDriver.Examples.Helpers
{
    static class WebDriverExtensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static void TakeScreenshot(this IWebDriver chromeDriver, string testName)
        {
            OpenQA.Selenium.Support.Extensions.WebDriverExtensions.TakeScreenshot(chromeDriver)
                .SaveAsFile("C:/tmp/" + string.Format("{0}_{1:yyyy-MM-dd-hh-mm-ss}.acceptance-exception.png", testName, DateTime.Now),
                    ImageFormat.Png);
        }
    }
}
