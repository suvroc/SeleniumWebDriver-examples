using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Protractor;

namespace SeleniumWebDriver.Examples.Chapter16
{
    [TestFixture]
    public class Ch16WebDriverTest
    {
        [Test]
        public void ShouldCheckElementByModel()
        {
            var chromeDriver = new ChromeDriver();
            var ngDriver = new NgWebDriver(chromeDriver);

            ngDriver.Navigate().GoToUrl("http://todomvc.com/examples/angularjs");

            var element = ngDriver.FindElement(NgBy.Model("newTodo"));

            Assert.IsTrue(element.Displayed);

            ngDriver.Quit();
        }
    }
}
