using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using System;
using System.Threading;

namespace BrowserStackTool.Pages
{
    public class SearchBook
    {
        public IWebDriver driver;

        public SearchBook(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_TopSearch1_txtSearch")]
        public IWebElement searchBook;

        [FindsBy(How = How.Id, Using = "ctl00_TopSearch1_Button1")]
        public IWebElement searchButton;

        [FindsBy(How = How.XPath, Using = "//html//body//form//div//div//div//div//div//h1")]
        public IWebElement spanResult;

        public string SearchBookMethod(string bookName)
        {
            Thread.Sleep(5000);
            searchBook.Click();
            searchBook.SendKeys(bookName);
            Thread.Sleep(3000);
            searchButton.Click();
            Thread.Sleep(5000);
            return spanResult.Text;
        }
    }
}
