using OpenQA.Selenium;
using SeleniumWebDriver.Examples.Chapter13.PageObjects.Base;

namespace SeleniumWebDriver.Examples.Chapter13.PageObjects
{
    public class NameScreenPageObject :
        BasePageObject, INameScreenPageObject
    {
        public NameScreenPageObject(IWebDriver driver)
            : base(driver)
        {
        }

        public IWebElement NextButton
        {
            get { return Driver.FindElement(By.Id("next1")); }
        }

        public IWebElement TitleInput
        {
            get { return Driver.FindElement(By.Id("title")); }
        }

        public IWebElement LocationInput
        {
            get { return Driver.FindElement(By.Id("location")); }
        }

        public IWebElement DescriptionInput
        {
            get { return Driver.FindElement(By.Id("description")); }
        }

        public IWebElement YourNameInput
        {
            get { return Driver.FindElement(By.Id("initiatorAlias")); }
        }

        public IWebElement EmailInput
        {
            get { return Driver.FindElement(By.Id("initiatorEmail")); }
        }

        public IWebElement BackButton
        {
            get { return Driver.FindElement(By.Id("back1")); }
        }
    }
}