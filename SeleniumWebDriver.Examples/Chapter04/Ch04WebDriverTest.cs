using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriver.Examples.Chapter04
{
    [TestFixture]
    public class Ch04WebDriverTest
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
        public void TheTest()
        {
            var driver = new ChromeDriver();
            var baseURL = "https://translate.google.com";

            driver.Navigate().GoToUrl(baseURL + "/#en/pl/cat");
            driver.FindElement(By.Id("source")).Clear();
            driver.FindElement(By.Id("source")).SendKeys("cat");
            for (int second = 0; ; second++)
            {
                if (second >= 60) Assert.Fail("timeout");
                try
                {
                    if ("kot" == driver.FindElement(By.Id("result_box")).Text) break;
                }
                catch (Exception)
                {
                    // ignored
                }
                Thread.Sleep(1000);
            }
            Assert.AreEqual("kot", driver.FindElement(By.Id("result_box")).Text);
        }


    }
}
