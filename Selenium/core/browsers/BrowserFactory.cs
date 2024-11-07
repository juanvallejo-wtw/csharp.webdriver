using System;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;

namespace Selenium.core.browsers
{
    public sealed class BrowserFactory :
         AbstractFactory,
         IBrowserWebDriver<FirefoxDriver>,
         IBrowserWebDriver<ChromeDriver>
    {
        IBrowser<ChromeDriver> IBrowserWebDriver<ChromeDriver>.Create()
        {
            // ChromeDriver can now be initialized without specifying the executable path
            var chromeOptions = new ChromeOptions();
            return new BrowserAdapter<ChromeDriver>(new ChromeDriver(chromeOptions), BrowserType.Chrome);
        }

        IBrowser<FirefoxDriver> IBrowserWebDriver<FirefoxDriver>.Create()
        {
            // FirefoxDriver can also be initialized without specifying the executable path
            var firefoxOptions = new FirefoxOptions();
            return new BrowserAdapter<FirefoxDriver>(new FirefoxDriver(firefoxOptions), BrowserType.Firefox);
        }
    }

    // TODO - Fix Remote WebDriver
    //IBrowser<RemoteWebDriver> IBrowserWebDriver<RemoteWebDriver>.Create()
    //{
    //    DesiredCapabilities capabilities;
    //    var gridUrl = Config.GridHubUri;

    //    switch (Config.Browser)
    //    {
    //        case BrowserType.Chrome:
    //            capabilities = new DesiredCapabilities();
    //            break;
    //        case BrowserType.Firefox:
    //            capabilities = new DesiredCapabilities();
    //            break;
    //        default:
    //            throw new ArgumentOutOfRangeException();
    //    }

    //    if (Config.RemoteBrowser && Config.UseSauceLabs)
    //    {
    //        capabilities.SetCapability(CapabilityType.Version, "50");
    //        capabilities.SetCapability(CapabilityType.Platform, "Windows 10");
    //        capabilities.SetCapability("username", Config.SauceLabsUsername);
    //        capabilities.SetCapability("accessKey", Config.SauceLabsAccessKey);
    //        gridUrl = Config.SauceLabsHubUri;
    //    }
    //    else if (Config.RemoteBrowser && Config.UseBrowserstack)
    //    {
    //        capabilities.SetCapability(CapabilityType.Version, "50");
    //        capabilities.SetCapability(CapabilityType.Platform, "Windows 10");
    //        capabilities.SetCapability("username", Config.BrowserStackUsername);
    //        capabilities.SetCapability("accessKey", Config.BrowserStackAccessKey);
    //        gridUrl = Config.BrowserStackHubUrl;
    //    }

    //    return
    //        new BrowserAdapter<RemoteWebDriver>(
    //            new RemoteWebDriver(new Uri(gridUrl), capabilities), BrowserType.Remote);
    //}
}
