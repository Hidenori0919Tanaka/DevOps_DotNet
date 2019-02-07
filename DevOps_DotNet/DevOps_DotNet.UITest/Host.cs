using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace DevOps_DotNet.UITest
{
    [SetUpFixture]
    public class Host
    {
        public static IisExpressWebServer WebServer;
        public static IWebDriver Browser;

        [SetUp]
        public void SetUp()
        {
            var app = new WebApplication(ProjectLocation.FromFolder("ContosoUniversity"), 12365);
            WebServer = new IisExpressWebServer(app);
            WebServer.Start();

            Browser = new FirefoxDriver();
        }

        [TearDown]
        public void TearDown()
        {
            Browser.Quit();
            WebServer.Stop();
        }
    }
}