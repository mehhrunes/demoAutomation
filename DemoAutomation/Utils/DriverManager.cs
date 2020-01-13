using System;
using DemoAutomation.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace DemoAutomation.Utils
{
    public class DriverManager
    {
        private Browser _browser;
        private static DriverManager _instance;
        public IWebDriver Driver { get; }

        private DriverManager()
        {
            Driver = GetDriver();
        }

        public static DriverManager GetInstance()
        {
            return _instance ??= new DriverManager();
        }

        private IWebDriver GetDriver()
        {
            GetBrowserFromConfig();
            return SelectDriver(_browser);
        }

        private void GetBrowserFromConfig()
        {
            Enum.TryParse(Config.CurrentConfig.Browser, out _browser);
        }

        private IWebDriver SelectDriver(Browser browser) => browser switch
        {
            Browser.Chrome => new ChromeDriver(GetOptions()),
            Browser.Firefox => new FirefoxDriver(),
            _ => throw new ArgumentException($"Unexpected browser type: {browser}")
        };


        private ChromeOptions GetOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            return options;
        }
    }
}