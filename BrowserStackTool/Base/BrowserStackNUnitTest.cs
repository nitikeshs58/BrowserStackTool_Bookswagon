// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Specialized;
using System.Configuration;

namespace BrowserStackTool
{
    [TestFixture]
    public class BrowserStackNUnitTest
    {
        protected IWebDriver driver;
        protected string profile;
        protected string environment;

        public BrowserStackNUnitTest(string profile, string environment)
        {
            this.profile = profile;
            this.environment = environment;
        }

        [OneTimeSetUp]
        [Obsolete]
        public void Init()
        {
            NameValueCollection caps = ConfigurationManager.GetSection("capabilities/" + profile) as NameValueCollection;
            NameValueCollection settings = ConfigurationManager.GetSection("environments/" + environment) as NameValueCollection;

            DesiredCapabilities capability = new DesiredCapabilities();

            foreach (string key in caps.AllKeys)
            {
                capability.SetCapability(key, caps[key]);
            }

            foreach (string key in settings.AllKeys)
            {
                capability.SetCapability(key, settings[key]);
            }

            String username = Environment.GetEnvironmentVariable("BROWSERSTACK_USERNAME");
            if (username == null)
            {
                username = ConfigurationManager.AppSettings.Get("user");
            }

            String accesskey = Environment.GetEnvironmentVariable("BROWSERSTACK_ACCESS_KEY");
            if (accesskey == null)
            {
                accesskey = ConfigurationManager.AppSettings.Get("key");
            }

            capability.SetCapability("browserstack.user", username);
            capability.SetCapability("browserstack.key", accesskey);

            String appId = Environment.GetEnvironmentVariable("BROWSERSTACK_APP_ID");
            if (appId != null)
            {
                capability.SetCapability("app", appId);
            }
            driver = new RemoteWebDriver(new Uri("http://" + ConfigurationManager.AppSettings.Get("server") + "/wd/hub/"), capability);
        }

        [OneTimeTearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}