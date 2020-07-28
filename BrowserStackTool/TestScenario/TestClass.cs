// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using BrowserStackTool.Credentials;
using BrowserStackTool.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace BrowserStackTool
{
    [TestFixture]
    public class TestClass
    {
        [TestFixture("single", "chrome")]
        public class SingleTest : BrowserStackNUnitTest
        {

            public SingleTest(string profile, string environment) : base(profile, environment)
            {
            }

            [Test, Order(1)]
            public void LoginTestMethod()
            {
                Login login = new Login(driver);
                driver.Url = JsonData.data.Url;
                login.LoginBookswagon(JsonData.data.UserEmail, JsonData.data.Password);
                string title = driver.Title;
                Assert.AreEqual(JsonData.data.title, title);
            }

            [Test, Order(2)]
            public void SearchBookTestMethod()
            {
                SearchBook addwish = new SearchBook(driver);
                string spanResult = addwish.SearchBookMethod(JsonData.data.SearchBook);
                string expectedSpanResult = "positive thinking";
                spanResult.Contains(expectedSpanResult);
            }

            [Test, Order(3)]
            public void PlaceOrderTestMethod()
            {
                PlaceOrder placeOrder = new PlaceOrder(driver);
                string cartHeader = placeOrder.BookOrder();
                cartHeader.Contains("my shopping cart");
            }

            [Test, Order(4)]
            public void CheckoutCartTestMethod()
            {
                Checkout checkout = new Checkout(driver);
                checkout.ChechOutCart();
                string cartUrl = "https://www.bookswagon.com/viewshoppingcart.aspx";
                Assert.AreEqual(cartUrl, driver.Url);
            }

            [Test, Order(5)]
            public void LogoutTestMethod()
            {
                Logout logout = new Logout(driver);
                logout.LogoutBookswagon();
            }
        }
    }
}
