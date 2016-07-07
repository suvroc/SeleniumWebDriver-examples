using Newtonsoft.Json;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver.Examples.Chapter17
{
    public class KendoGridElement
    {
        private readonly string gridId;
        private readonly IJavaScriptExecutor driver;

        public KendoGridElement(IWebDriver driver, IWebElement gridDiv)
        {
            this.gridId = gridDiv.GetAttribute("id");
            this.driver = (IJavaScriptExecutor)driver;
        }

        public void NavigateToPage(int pageNumber)
        {
            string jsToBeExecuted = this.GetGridReference();
            jsToBeExecuted = string.Concat(jsToBeExecuted, "grid.dataSource.page(", pageNumber, ");");
            this.driver.ExecuteScript(jsToBeExecuted);
        }

        public List<T> GetItems<T>() where T : class
        {
            string jsToBeExecuted = this.GetGridReference();
            jsToBeExecuted = string.Concat(jsToBeExecuted, "return JSON.stringify(grid.dataSource.data());");
            var jsResults = this.driver.ExecuteScript(jsToBeExecuted);
            var items = JsonConvert.DeserializeObject<List<T>>(jsResults.ToString());
            return items;
        }
        private string GetGridReference()
        {
            return string.Format("var grid = $('#{0}').data('kendoGrid');", this.gridId);
        }
    }
}
