using OpenQA.Selenium;

namespace SeleniumWebDriver.Examples.Chapter07.Helpers
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
