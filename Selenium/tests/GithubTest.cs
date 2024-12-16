using NUnit.Framework;
using Selenium.core;
using Selenium.core.browsers;
using Selenium.pages;

namespace Selenium.tests
{
    [TestFixture]
    [Parallelizable]
    public class GithubTest : TestBase
    {
        [Test]
        public void TestMethod()
        {
            var page = new HomePage(Driver);
            page.OpenGithubPage();


            // Log relevant configuration details using TestContext
            TestContext.WriteLine("Test Run Configuration:");
            TestContext.WriteLine($"Browser: {Config.Browser}");
            TestContext.WriteLine($"Platform: {Config.Platform}");
            TestContext.WriteLine($"Base URL: {Config.BaseUrl}");
            TestContext.WriteLine($"Using Selenium Grid: {Config.UseSeleniumGrid}");
            TestContext.WriteLine($"Using Sauce Labs: {Config.UseSauceLabs}");
            TestContext.WriteLine($"Using BrowserStack: {Config.UseBrowserstack}");
        }
    }
}