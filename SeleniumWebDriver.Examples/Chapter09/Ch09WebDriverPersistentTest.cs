using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriver.Examples.Chapter09
{
    [TestFixture]
    public class Ch09WebDriverPersistentTest : BaseTestCasePersistent
    {
        [Test]
        public void ShouldCheckElementPropertiesPersistent()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var element = driver.FindElement(By.Id("createExample"));

            Assert.IsTrue(element.Displayed);
            Assert.IsTrue(element.Enabled);
            Assert.IsTrue(!element.Selected);
            Assert.IsTrue(element.Text == "View example");
            Assert.IsTrue(element.Location.X > 0);
            Assert.IsTrue(element.Location.Y > 0);
            Assert.IsTrue(element.Size.Height > 0);
            Assert.IsTrue(element.Size.Width > 0);
            Assert.IsTrue(element.TagName == "button");
            Assert.IsTrue(element.GetAttribute("type") == "submit");

            driver.Quit();
        }
    }
}