using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Protractor;

namespace SeleniumWebDriver.Examples.Chapter17
{
    [TestFixture]
    public class Ch17WebDriverTest
    {
        [Test]
        public void ShouldCheckElementByModel()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://demos.telerik.com/kendo-ui/grid/index");

            var element = driver.FindElement(By.Id("grid"));

            var grid = new KendoGridElement(driver, element);

            var items = grid.GetItems<DummyClass>();

            Assert.IsTrue(items.Count > 0);

            driver.Quit();
        }
    }

    class DummyClass
    {

    }
}
