using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver.Examples.Chapter08
{
    [TestFixture]
    public class Ch08WebDriverTest
    {
        [Test]
        public void ShouldCheckElementProperties()
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

        [Test]
        public void ShouldClickOnlyIfPossibe()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var sourceInput = driver.FindElement(By.PartialLinkText("Contents"));

            if (sourceInput.Displayed && sourceInput.Enabled)
            {
                sourceInput.Click();
            }

            driver.Quit();
        }

        [Test]
        public void ShouldFindText()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var source = driver.FindElement(By.Id("mp-left"));

            var text = source.Text;

            driver.Quit();
        }

        [Test]
        public void ShouldSearchAndEnter()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var element = driver.FindElement(By.Id("searchInput"));

            element.SendKeys("cat");
            element.SendKeys(Keys.Enter);

            driver.Quit();
        }

        [Test]
        public void ShouldSaveShortcut()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var element = driver.FindElement(By.Id("searchInput"));

            Actions action = new Actions(driver);
            var saveShortcut = action.ContextClick(element)
                .KeyDown(Keys.Control)
                .KeyDown("S")
                .Build();

            saveShortcut.Perform();

            driver.Quit();
        }

        [Test]
        public void ShouldCopyShortcut()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var element = driver.FindElement(By.Id("searchInput"));

            Actions action = new Actions(driver);
            var saveShortcut = action.ContextClick(element)
                .KeyDown(Keys.Control)
                .KeyDown("C")
                .Build();

            saveShortcut.Perform();
            saveShortcut.Perform();

            driver.Quit();
        }

        [Test]
        public void ShouldContextClick()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var element = driver.FindElement(By.Id("searchInput"));

            Actions action = new Actions(driver);
            action.ContextClick(element)
                .SendKeys(Keys.ArrowUp)
                .SendKeys(Keys.Enter)
                .Build()
                .Perform();

            driver.Quit();
        }

        [Test]
        public void ShouldUploadFile()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://postimage.org/");

            var element = driver.FindElement(By.Id("file_upload"));

            element.SendKeys(TestContext.CurrentContext.TestDirectory + "\\TestFiles\\TestFile.png");

            driver.FindElement(By.Id("l_adult_no")).Click();

            driver.FindElement(By.Id("btSubmit")).Click();

            driver.Quit();
        }

        [Test]
        public void ShouldTouch()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var element = driver.FindElement(By.Id("searchInput"));

            TouchActions touchActions = new TouchActions(driver);
            touchActions.SingleTap(element)
                .Perform();

            driver.Quit();
        }

        [Test]
        public void ShouldSelectItemManually()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://getbootstrap.com/css/");

            var select = driver.FindElement(By.TagName("select"));

            var options = select.FindElements(By.TagName("option"));
            foreach (var option in options)
            {
                if (option.Text == "2")
                    option.Click();
            }

            driver.Quit();
        }

        [Test]
        public void ShouldSelectItem()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://getbootstrap.com/css/");

            var element = driver.FindElement(By.TagName("select"));

            var selectElement = new SelectElement(element);

            selectElement.SelectByText("2");
            selectElement.SelectByValue("2");
            selectElement.SelectByIndex(2);

            selectElement.SelectByIndex(5);

            driver.Quit();
        }
    }
}
