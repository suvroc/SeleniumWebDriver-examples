using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriver.Examples.Chapter07.Helpers;

namespace SeleniumWebDriver.Examples.Chapter07
{
    [TestFixture]
    public class Ch07WebDriverTest
    {
        [Test]
        public void ShouldGetElementByClassName()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var element = driver.FindElement(By.ClassName("contentPart"));

            Assert.IsTrue(element.Text == "Doodle simplifies scheduling");

            driver.Quit();
        }

        [Test]
        public void ShouldGetElementByCss()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var element = driver.FindElement(By.CssSelector("#doodleExample > div.wizardOrExample.spaceBBefore > a"));

            Assert.IsTrue(element.Text.Contains("Schedule an event"));

            driver.Quit();
        }

        [Test]
        public void ShouldGetElementById()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var element = driver.FindElement(By.Id("createExample"));

            Assert.IsTrue(element.Text.Contains("View example"));

            driver.Quit();
        }

        [Test]
        public void ShouldGetElementByJavaScript()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var element = (IWebElement) ((IJavaScriptExecutor) driver).ExecuteScript("return $('#createExample')[0]");

            Assert.IsTrue(element.Text.Contains("View example"));

            driver.Quit();
        }

        [Test]
        public void ShouldGetElementByLinkText()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var element = driver.FindElement(By.LinkText("Features"));

            Assert.IsTrue(element.Text.Contains("Features"));

            driver.Quit();
        }

        [Test]
        public void ShouldGetElementByName()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://doodle.com/create");

            var element = driver.FindElement(By.Name("eMailAddress"));

            Assert.IsTrue(element != null);

            driver.Quit();
        }

        [Test]
        public void ShouldGetElementByPartialLinkText()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var element = driver.FindElement(By.PartialLinkText("Schedule"));

            Assert.IsTrue(element.Text.Contains("Schedule an event"));

            driver.Quit();
        }

        [Test]
        public void ShouldGetElementByTag()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var element = driver.FindElement(By.TagName("h1"));

            Assert.IsTrue(element.Text == "Doodle simplifies scheduling");

            driver.Quit();
        }

        [Test]
        public void ShouldGetElementByXPath()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var element = driver.FindElement(By.XPath("//*[@id='doodleExample']/div[1]/a"));

            Assert.IsTrue(element.Text.Contains("Schedule an event"));

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

            var houseTile = houseTiles.First();

            var link = houseTile.Element
                .FindElement(By.ClassName("thumb"));

            link.Click();

            driver.Quit();
        }
    }
}