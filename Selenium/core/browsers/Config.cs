using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Selenium.core.browsers
{
    public class Config
    {
        private static IConfigurationRoot Configuration { get; } = BuildConfiguration();

        public static bool RemoteBrowser => GetBoolValue("RemoteBrowser");

        public static BrowserType Browser
        {
            get
            {
                var browserFromEnv = Environment.GetEnvironmentVariable("Browser");
                if (!string.IsNullOrEmpty(browserFromEnv) && Enum.TryParse(browserFromEnv, true, out BrowserType browser))
                {
                    Console.WriteLine($"Using Browser from Environment: {browser}");
                    return browser;
                }
                else
                {
                    Console.WriteLine($"Using Browser from appsettings.json: {GetValue("Browser")}");
                    return (BrowserType)Enum.Parse(typeof(BrowserType), GetValue("Browser"));
                }
            }
        }

        public static string Platform => GetValue("Platform");
        public static string BaseUrl => GetValue("BaseUrl");
        public static string Username => GetValue("Username");
        public static string Password => GetValue("Password");

        public static bool UseSeleniumGrid => GetBoolValue("UseSeleniumGrid");
        public static string GridHubUri => GetValue("GridHubUrl");

        public static bool UseSauceLabs => GetBoolValue("UseSauceLabs");
        public static string SauceLabsHubUri => GetValue("SauceLabsHubUrl");
        public static string SauceLabsUsername => GetValue("SauceLabsUsername");
        public static string SauceLabsAccessKey => GetValue("SauceLabsAccessKey");

        public static bool UseBrowserstack => GetBoolValue("UseBrowserstack");
        public static string BrowserStackHubUrl => GetValue("BrowserStackHubUrl");
        public static string BrowserStackUsername => GetValue("BrowserStackUsername");
        public static string BrowserStackAccessKey => GetValue("BrowserStackAccessKey");

        private static string GetValue(string key)
        {
            return Environment.GetEnvironmentVariable(key) ?? Configuration[key];
        }

        private static bool GetBoolValue(string key)
        {
            return bool.TryParse(GetValue(key), out bool result) && result;
        }

        private static IConfigurationRoot BuildConfiguration()
        {
            var dirName = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            var fileInfo = new FileInfo(dirName);
            var parentDirName = fileInfo?.FullName;

            var builder = new ConfigurationBuilder()
                .SetBasePath(parentDirName)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            return builder.Build();
        }
    }
}