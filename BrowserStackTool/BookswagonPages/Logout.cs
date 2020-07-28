using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using System;
using System.Threading;

namespace BrowserStackTool.Pages
{
    public class Logout
    {
        public IWebDriver driver;

        public Logout(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "ctl00_lnkbtnLogout")]
        public IWebElement logoutButton;

        public void LogoutBookswagon()
        {
            Thread.Sleep(3000);
            logoutButton.Click();
        }
    }
}
