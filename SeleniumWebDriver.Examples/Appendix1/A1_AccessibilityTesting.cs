using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Drawing.Imaging;
using System.IO;

namespace SeleniumWebDriver.Examples.Appendix1
{
    [TestFixture]
    public class A1_AccessibilityTesting
    {
        [Test]
        public void AccessibilityTest()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddExtension(@"D:\Projekty\GitHub\SeleniumWebDriver-examples\SeleniumWebDriver.Examples\WAVE-Evaluation-Tool_v1.0.1.crx");
            var driver = new ChromeDriver(options);

            driver.Navigate().GoToUrl("chrome://extensions-frame/");
            driver.FindElement(By.XPath("//a[@class='extension-commands-config']")).Click();
            driver.FindElement(By.XPath("//span[@class='command-shortcut-text']")).SendKeys(Keys.Control + "m");
            driver.FindElement(By.Id("extension-commands-dismiss")).Click();



            driver.Navigate().GoToUrl("http://www.google.pl");
            //driver.FindElement(By.TagName("body")).SendKeys(Keys.Control + "t");

            new Actions(driver).KeyDown(Keys.Control).SendKeys("m").Build().Perform();


            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.ElementExists(By.ClassName("wave5icon")));

            var waveTips = driver.FindElements(By.ClassName("wave5icon"));
            if (waveTips.Count == 0) Assert.Fail("Could not locate any WAVE validations - please ensure that WAVE is installed correctly");
            foreach (var waveTip in waveTips)
            {
                if (!waveTip.GetAttribute("alt").StartsWith("ERROR")) continue;

                var fileName = String.Format("{0}{1}{2}", "WAVE", DateTime.Now.ToString("HHmmss"), ".png");
                var screenShot = ((ITakesScreenshot)driver).GetScreenshot();
                screenShot.SaveAsFile(Path.Combine(System.IO.Path.GetTempPath(), fileName), ImageFormat.Png);
                driver.Close();
                Assert.Fail("WAVE errors were found on the page. Please see screenshot for details");
            }
            driver.Close();
        }
    }
}
