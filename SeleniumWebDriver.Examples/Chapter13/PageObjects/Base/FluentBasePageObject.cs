using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumWebDriver.Examples.Chapter13.PageObjects.Base
{
    public abstract class FluentBasePageObject<T>
        where T : class
    {
        public FluentBasePageObject(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }

        public IWebDriver Driver { get; set; }

        public T AssertThat(Func<T, bool> condition, string message)
        {
            Assert.IsTrue(condition(this as T), message);
            return this as T;
        }

        public T Then(Action<T> action)
        {
            action(this as T);
            return this as T;
        }

        public T ClickButton(Func<T, IWebElement> selector)
        {
            selector(this as T).Click();
            return this as T;
        }
    }
}