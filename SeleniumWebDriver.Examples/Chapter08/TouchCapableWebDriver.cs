using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver.Examples.Chapter08
{
    public class TouchCapableChromeDriver : ChromeDriver, IHasTouchScreen
    {
        public ITouchScreen TouchScreen
        {
            get
            {
                return new RemoteTouchScreen(this);
            }
        }
    }
}
