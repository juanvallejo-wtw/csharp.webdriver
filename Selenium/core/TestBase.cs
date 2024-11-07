using System;
using NUnit.Framework;
using Selenium.core.browsers;

namespace Selenium.core
{
    [SetUpFixture]
    public class TestBase
    {
        private readonly Lazy<BrowserFactory> _factory = new Lazy<BrowserFactory>();
        protected IBrowser Driver;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            // Initializes the browser based on the configuration
            Driver = _factory.Value.GetBrowser(Config.Browser);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            // Quit the browser after tests are complete
            Driver.Page.Quit();
        }
    }
}
