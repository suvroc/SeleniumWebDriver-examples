using OpenQA.Selenium;
using SeleniumWebDriver.Examples.Chapter13.Helpers;
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

        public NavigateButton<DateScreenPageObject> NextButtonObject
        {
            get
            {
                return new NavigateButton<DateScreenPageObject>(Driver.FindElement(By.Id("next1")),
                    () => new DateScreenPageObject(Driver));
            }
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

        public NameScreenPageObject FillData(string title, string name, string email)
        {
            TitleInput.SendKeys(title);
            YourNameInput.SendKeys(name);
            EmailInput.SendKeys(email);

            return this;
        }

        public DateScreenPageObject NavigateToNextPage()
        {
            //NextButton.Click();

            return new DateScreenPageObject(Driver);
        }
    }
}