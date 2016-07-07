using OpenQA.Selenium;
using System;

namespace SeleniumWebDriver.Examples.Helpers
{
    public class NavigateButton<PageObjectType>
    {
        private readonly Func<PageObjectType> _factory;
        private readonly IWebElement _button;

        public NavigateButton(IWebElement button, Func<PageObjectType> factory)
        {
            _factory = factory;
            _button = button;
        }

        public PageObjectType Navigate()
        {
            _button.Click();
            return _factory();
        }
    }
}
