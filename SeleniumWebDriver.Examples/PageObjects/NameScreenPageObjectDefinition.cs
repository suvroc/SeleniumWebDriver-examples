using OpenQA.Selenium;

namespace SeleniumWebDriver.Examples.PageObjects
{

    public class NameScreenPageObjectDefinition : BasePageObject
    {
        public NameScreenPageObjectDefinition(IWebDriver driver)
            : base(driver)
        { }

        public IWebElement TitleInput { get; set; }

        public IWebElement LocationInput { get; set; }




        public IWebElement DescriptionInput { get; set; }











        public IWebElement YourNameInput { get; set; }




        public IWebElement EmailInput { get; set; }







        public IWebElement BackButton { get; set; }

        public IWebElement NextButton { get; set; }
    }
}