using OpenQA.Selenium;

namespace SeleniumWebDriver.Examples.Chapter13.PageObjects
{
    public interface INameScreenPageObject
    {
        IWebElement TitleInput { get; }

        IWebElement LocationInput { get; }

        IWebElement DescriptionInput { get; }

        IWebElement YourNameInput { get; }

        IWebElement EmailInput { get; }

        IWebElement BackButton { get; }
    }
}