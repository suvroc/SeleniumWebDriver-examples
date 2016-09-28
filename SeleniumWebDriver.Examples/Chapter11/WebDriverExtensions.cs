using System;
using System.Drawing.Imaging;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.IO;

namespace SeleniumWebDriver.Examples.Chapter11
{
    internal static class WebDriverExtensions
    {
        public static void TakeScreenshot(this IWebDriver chromeDriver, string testName)
        {
            OpenQA.Selenium.Support.Extensions.WebDriverExtensions.TakeScreenshot(chromeDriver)
                .SaveAsFile(
                    "C:/tmp/" +
                    EscapeFilename(string.Format("{0}_{1:yyyy-MM-dd-hh-mm-ss}.acceptance-exception.png", ShortName(testName), DateTime.Now)),
                    ImageFormat.Png);
        }

        private static string ShortName(string testName)
        {
            return testName.Substring(0, testName.Length > 100 ? 100 : testName.Length);
        }

        public static string EscapeFilename(string filePath)
        {
            return Regex.Replace(filePath, "[" + Regex.Escape(new string(Path.GetInvalidFileNameChars())) + "]", "_");
        }
    }
}