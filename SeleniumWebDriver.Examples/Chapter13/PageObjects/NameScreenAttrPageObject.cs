using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumWebDriver.Examples.Chapter13.Helpers;
using SeleniumWebDriver.Examples.Chapter13.PageObjects.Base;
using System;

namespace SeleniumWebDriver.Examples.Chapter13.PageObjects
{
    public class NameScreenAttrPageObject :
        FluentBasePageObject<NameScreenAttrPageObject>, INameScreenPageObject
    {
        public NameScreenAttrPageObject(IWebDriver driver)
            : base(driver)
        {
        }

        public NavigateButton<DateScreenPageObject> NextButton
        {
            get
            {
                return new NavigateButton<DateScreenPageObject>(Driver.FindElement(By.Id("next1")),
                    () => new DateScreenPageObject(Driver));
            }
        }

        [FindsBy(How = How.Id, Using = "title")]
        public IWebElement TitleInput { get; set; }

        [FindsBy(How = How.Id, Using = "location")]
        public IWebElement LocationInput { get; set; }

        [FindsBy(How = How.Id, Using = "description")]
        public IWebElement DescriptionInput { get; set; }

        [FindsBy(How = How.Id, Using = "initiatorAlias")]
        public IWebElement YourNameInput { get; set; }

        [FindsBy(How = How.Id, Using = "initiatorEmail")]
        public IWebElement EmailInput { get; set; }

        [FindsBy(How = How.Id, Using = "back1")]
        public IWebElement BackButton { get; set; }

        public NameScreenAttrPageObject FillData(string title, string name, string email)
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