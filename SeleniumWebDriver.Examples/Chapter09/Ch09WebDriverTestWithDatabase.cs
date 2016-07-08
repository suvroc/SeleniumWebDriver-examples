using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumWebDriver.Examples.Chapter09
{
    [TestFixture]
    public class Ch09WebDriverTestWithDatabase : BaseTestCaseWithDatabase
    {
        [Test]
        public void ShouldCheckElementPropertiesWithDatabase()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://doodle.com/en_GB/");

            var element = driver.FindElement(By.ClassName("createExample"));

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