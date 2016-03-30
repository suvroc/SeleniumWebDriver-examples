using OpenQA.Selenium;

namespace SeleniumWebDriver.Examples.Helpers
{
    public class ListItem
    {
        public ListItem(string name, IWebElement element)
        {
            this.Name = name;
            this.Element = element;
        }

        public string Name { get; set; }
        public IWebElement Element { get; set; }
    }
}
