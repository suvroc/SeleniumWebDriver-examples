using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebDriver.Examples.PageObjects;

namespace SeleniumWebDriver.Examples.PageObjectsAttributed
{
    public class NameScreenPageObject : BasePageObject
    {
        public NameScreenPageObject(IWebDriver driver)
            : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "title")]
        public IWebElement TitleInput { get; }

        [FindsBy(How = How.Id, Using = "location")]
        public IWebElement LocationInput { get; }

        [FindsBy(How = How.Id, Using = "description")]
        public IWebElement DescriptionInput { get; }

        [FindsBy(How = How.Id, Using = "initiatorAlias")]
        public IWebElement YourNameInput { get; }

        [FindsBy(How = How.Id, Using = "initiatorEmail")]
        public IWebElement EmailInput { get; }

        [FindsBy(How = How.Id, Using = "back1")]
        public IWebElement BackButton { get; }

        [FindsBy(How = How.Id, Using = "next1")]
        public IWebElement NextButton { get; }
    }
}