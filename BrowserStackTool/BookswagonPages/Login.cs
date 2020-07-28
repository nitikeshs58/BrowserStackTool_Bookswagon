using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;
using FindsByAttribute = SeleniumExtras.PageObjects.FindsByAttribute;
using System;
using System.Threading;

namespace BrowserStackTool.Pages
{
    public class Login
    {
        public IWebDriver driver;

        public Login(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_phBody_SignIn_txtEmail']")]
        public IWebElement userEmail;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_phBody_SignIn_txtPassword']")]
        public IWebElement passWord;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_phBody_SignIn_btnLogin']")]
        public IWebElement loginButton;

        public void LoginBookswagon(string email, string password)
        {
            Thread.Sleep(5000);
            userEmail.SendKeys(email);
            Thread.Sleep(1000);
            passWord.SendKeys(password);
            Thread.Sleep(3000);
            loginButton.Click();
            Thread.Sleep(3000);
        }
    }
}
