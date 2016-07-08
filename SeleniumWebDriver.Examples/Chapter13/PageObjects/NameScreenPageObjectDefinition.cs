using OpenQA.Selenium;
using SeleniumWebDriver.Examples.Chapter13.PageObjects.Base;

namespace SeleniumWebDriver.Examples.Chapter13.PageObjects
{
    public class NameScreenPageObjectDefinition :
        BasePageObject, INameScreenPageObject
    {
        public NameScreenPageObjectDefinition(IWebDriver driver)
            : base(driver)
        {
        }

        public IWebElement NextButton { get; set; }

        public IWebElement TitleInput { get; set; }

        public IWebElement LocationInput { get; set; }


        public IWebElement DescriptionInput { get; set; }


        public IWebElement YourNameInput { get; set; }


        public IWebElement EmailInput { get; set; }


        public IWebElement BackButton { get; set; }
    }
}