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

            // Log relevant configuration details
            Console.WriteLine("Test Run Configuration:");
            Console.WriteLine($"Browser: {Config.Browser}");
            Console.WriteLine($"Platform: {Config.Platform}");
            Console.WriteLine($"Base URL: {Config.BaseUrl}");
            Console.WriteLine($"Using Selenium Grid: {Config.UseSeleniumGrid}");
            Console.WriteLine($"Using Sauce Labs: {Config.UseSauceLabs}");
            Console.WriteLine($"Using BrowserStack: {Config.UseBrowserstack}");
        }
    }
}
