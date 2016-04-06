using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.IE;
using System;
using System.Threading;
using System.Linq;
using SeleniumWebDriver.Examples.Helpers;
using OpenQA.Selenium.Interactions;
using System.IO;
using OpenQA.Selenium.Support.UI;

namespace SeleniumWebDriver.Examples
{
    [TestFixture]
    public class BasicWebDriverTest
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
        public void ShouldNavigate()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var sourceInput = driver.FindElement(By.PartialLinkText("Contents"));

            sourceInput.Click();

            Thread.Sleep(500);

            driver.Navigate().Back();

            Assert.IsTrue(driver.Title.Contains("Wikipedia"));

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

            var houseTile = houseTiles.Single(x => x.Name == "Buiding.jpg");

            var link = houseTile.Element
                .FindElement(By.ClassName("thumb"));

            link.Click();

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
                .KeyDown("C")
                .Build();

            saveShortcut.Perform();
            saveShortcut.Perform();

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

        [Test]
        public void ShouldClearLocalStorageAndCookies()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://getbootstrap.com/css/");

            driver.ExecuteScript("window.localStorage.clear();");
            driver.Manage().Cookies.DeleteAllCookies();

            var element = driver.FindElement(By.TagName("select"));

            var selectElement = new SelectElement(element);

            selectElement.SelectByText("2");
            selectElement.SelectByValue("2");
            selectElement.SelectByIndex(2);

            selectElement.SelectByIndex(5);

            driver.Quit();
        }

        [Test]
        public void ShouldSetTimeouts()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://getbootstrap.com/css/");

            driver.Manage().Timeouts()
                .SetScriptTimeout(TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts()
                .SetPageLoadTimeout(TimeSpan.FromSeconds(10));

            driver.Quit();
        }

        [Test]
        public void ShouldImplicitWait()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://getbootstrap.com/css/");

            driver.Manage().Timeouts()
                .ImplicitlyWait(TimeSpan.FromSeconds(10));

            driver.Quit();
        }

        [Test]
        public void ShouldExplicitWait()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://getbootstrap.com/css/");

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // TODO: fix id
            wait.Until(ExpectedConditions.ElementToBeClickable(
                By.Id("buttonId")));

            driver.Quit();
        }

        [Test]
        public void ShouldExplicitDynamicWait()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://getbootstrap.com/css/");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement myDynamicElement = wait.Until<IWebElement>((d) =>
            {
                // TODO: fix id
                return d.FindElement(By.Id("someDynamicElement"));
            });

            driver.Quit();
        }

        [Test]
        public void ShouldUseFindElementExtension()
        {
            var driver = new ChromeDriver();

            driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");

            var element = driver.FindElement(By.Id("searchInput"), 10);

            driver.Quit();
        }

        [Test]
        public void ShouldThrowException()
        {
            var driver = new ChromeDriver();
            try
            {
                driver.Navigate().GoToUrl("https://en.wikipedia.org/wiki/Main_Page");
                // ...
                throw new NotFoundException("Test error");
            }
            catch (Exception ex)
            {
                driver.TakeScreenshot("ShouldThrowException");
                throw;
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
