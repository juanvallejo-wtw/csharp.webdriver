using NUnit.Framework;
using Selenium.core;
using Selenium.core.browsers;
using Selenium.pages;
using System;

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