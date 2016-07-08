using System;
using OpenQA.Selenium;

namespace SeleniumWebDriver.Examples.Chapter13.Helpers
{
    public class NavigateButton<TPageObjectType>
    {
        private readonly IWebElement _button;
        private readonly Func<TPageObjectType> _factory;

        public NavigateButton(IWebElement button, Func<TPageObjectType> factory)
        {
            _factory = factory;
            _button = button;
        }

        public TPageObjectType Navigate()
        {
            _button.Click();
            return _factory();
        }
    }
}