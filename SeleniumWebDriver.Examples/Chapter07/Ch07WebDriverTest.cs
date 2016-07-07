using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWebDriver.Examples.Helpers;

namespace SeleniumWebDriver.Examples.Chapter07
{
    [TestFixture]
    public class Ch07WebDriverTest
    {
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

            var houseTile = houseTiles.Single(x => x.Name == "Buiding.jpg");

            var link = houseTile.Element
                .FindElement(By.ClassName("thumb"));

            link.Click();

            driver.Quit();
        }

        [Test]
        public void ShouldGetElementById()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            

            driver.Quit();
        }
    }
}
