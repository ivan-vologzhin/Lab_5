using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Lab_5
{


    public class SearchFilterPage
    {
        private IWebDriver driver;
        private By input1 = By.Id("input1");
        private By input2 = By.Id("input2");
        private By input3 = By.Id("input3");

        public SearchFilterPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SelectSearchByPayee(string data)
        {
            driver.FindElement(input1).Clear();
            driver.FindElement(input1).SendKeys(data);
        }

        public void SelectSearchByAccount()
        {
            driver.FindElement(input2).Click();
        }

        public void SelectAccount(string accountName)
        {
            var dropdown = driver.FindElement(input2);
            var select = new SelectElement(dropdown);
            select.SelectByText(accountName);
        }

        public void SelectSearchByType()
        {
            driver.FindElement(input3).Click();
        }

        public void SelectType(string typeName)
        {
            var dropdown = driver.FindElement(By.Id("input3"));
            var select = new SelectElement(dropdown);
            select.SelectByText(typeName);
        }

        public IList<List<string>> GetSearchResults()
        {
            var results = driver.FindElements(By.XPath("//tr[@class='ng-scope']"));
            var resultTexts = new List<List<string>>();
            foreach (var result in results)
            {
                var locResult = new List<string>();
                foreach (var elm in result.FindElements(By.TagName("td")).Skip(1))
                {
                    locResult.Add(elm.Text);
                }
                resultTexts.Add(locResult);

            }
            return resultTexts;
        }
    }
}
