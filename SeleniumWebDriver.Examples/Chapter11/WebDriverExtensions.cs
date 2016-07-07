using OpenQA.Selenium;
using System;
using System.Drawing.Imaging;

namespace SeleniumWebDriver.Examples.Chapter11
{
    static class WebDriverExtensions
    {
        public static void TakeScreenshot(this IWebDriver chromeDriver, string testName)
        {
            OpenQA.Selenium.Support.Extensions.WebDriverExtensions.TakeScreenshot(chromeDriver)
                .SaveAsFile("C:/tmp/" + string.Format("{0}_{1:yyyy-MM-dd-hh-mm-ss}.acceptance-exception.png", testName, DateTime.Now),
                    ImageFormat.Png);
        }
    }
}
