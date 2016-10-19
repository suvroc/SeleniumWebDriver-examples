using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Threading;

namespace SeleniumWebDriver.Examples.Appendix1
{
    [TestFixture]
    public class A1_MultipleBrowserTest
    {
        [Test]
        public void ShouldTranslateWord()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://translate.google.com/#en/pl");

            var sourceTextBox = driver.FindElement(By.Id("source"));
            sourceTextBox.SendKeys("cat");

            driver.FindElement(By.Id("gt-submit")).Click();

            var resultTextBox = driver.FindElement(By.Id("result_box"));

            Thread.Sleep(500);

            Assert.AreEqual(resultTextBox.Text, "kot");
        }

        [Test, TestCaseSource("ResponsiveWebDrivers")]
        public void ShouldTranslateWord(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://translate.google.com/#en/pl");

            var sourceTextBox = driver.FindElement(By.Id("source"));
            sourceTextBox.SendKeys("cat");

            driver.FindElement(By.Id("gt-submit")).Click();

            var resultTextBox = driver.FindElement(By.Id("result_box"));

            Thread.Sleep(500);

            Assert.AreEqual(resultTextBox.Text, "kot");
        }

        [Test, TestCaseSource("ResponsiveWebDrivers")]
        public void ShouldDoOther(IWebDriver driver)
        {
            // ....
        }

        [Test]
        public void BrowserStackTest()
        {
            IWebDriver driver;
            DesiredCapabilities capability = DesiredCapabilities.Firefox();
            capability.SetCapability("browserstack.user", "USERNAME");
            capability.SetCapability("browserstack.key", "ACCESS_KEY");

            capability.SetCapability("browser", "IE");
            capability.SetCapability("browser_version", "7.0");
            capability.SetCapability("os", "Windows");
            capability.SetCapability("os_version", "XP");
            capability.SetCapability("resolution", "800x600");

            driver = new RemoteWebDriver(
              new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capability
            );
            driver.Navigate().GoToUrl("http://www.google.com");
            Console.WriteLine(driver.Title);

            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Browserstack");
            query.Submit();
            Console.WriteLine(driver.Title);

            driver.Quit();
        }

        //public static IEnumerable<IWebDriver> TestingWebDrivers
        //{
        //    get {
        //        ChromeOptions options = new ChromeOptions();
        //        options.AddExtensions("/path/to/extension.crx");

        //        Proxy proxy = new Proxy();
        //        proxy.HttpProxy = "myhttpproxy:3337";

        //        var options2 = new ChromeOptions();
        //        options2.AddAdditionalCapability("proxy", proxy);

        //        return new IWebDriver[]
        //        {
        //            // regular Chrome
        //            new ChromeDriver(),
        //            // Chrome with extension
        //            new ChromeDriver(options),
        //            // Chrome behind proxy
        //            new ChromeDriver(options2),

        //        new FirefoxDriver(),
        //            new OperaDriver(),
        //            new SafariDriver()
        //        };
        //    }
        //}

        public static IEnumerable<IWebDriver> ResponsiveWebDrivers
        {
            get
            {
                return new IWebDriver[]
                {
                    new ChromeDriver(),
                    new ChromeResponsiveDriver("Nexus 5"),
                    new ChromeResponsiveDriver("Galaxy S5"),
                    new ChromeResponsiveDriver("iPhone 6"),
                    new ChromeResponsiveDriver(new ChromeMobileEmulationDeviceSettings()
                    {
                        EnableTouchEvents = true,
                        Width = 480,
                        Height = 640,
                        PixelRatio = 3.0,
                        UserAgent = "Mozilla/5.0 (Linux; Android 4.2.1; en-us; Nexus 5 Build/JOP40D)"
                    })
                };
            }
        }
    }

    public class ChromeResponsiveDriver : ChromeDriver
    {
        public ChromeResponsiveDriver(string deviceName) 
            : base(BuildChromeCapabilities(deviceName))
        {
        }

        public ChromeResponsiveDriver(ChromeMobileEmulationDeviceSettings deviceSettings) 
            : base(BuildChromeCapabilities(deviceSettings))
        {
        }

        private static ChromeOptions BuildChromeCapabilities(string deviceName)
        {
            ChromeOptions chromeCapabilities = new ChromeOptions();
            chromeCapabilities.EnableMobileEmulation(deviceName);
            return chromeCapabilities;
        }

        private static ChromeOptions BuildChromeCapabilities(
            ChromeMobileEmulationDeviceSettings deviceSettings)
        {
            ChromeOptions chromeCapabilities = new ChromeOptions();
            chromeCapabilities.EnableMobileEmulation(deviceSettings);
            return chromeCapabilities;
        }
    }

    public class FirefoxProfileOptions : FirefoxOptions
    {
        private DesiredCapabilities _capabilities;

        public FirefoxProfileOptions()
            : base()
        {
            _capabilities = DesiredCapabilities.Firefox();
            _capabilities.SetCapability("marionette", true);
        }

        public FirefoxProfileOptions(FirefoxProfile profile)
            : this()
        {
            _capabilities.SetCapability(FirefoxDriver.ProfileCapabilityName, profile.ToBase64String());
        }

        public override void AddAdditionalCapability(string capabilityName, object capabilityValue)
        {
            _capabilities.SetCapability(capabilityName, capabilityValue);
        }

        public override ICapabilities ToCapabilities()
        {
            return _capabilities;
        }
    }
}
