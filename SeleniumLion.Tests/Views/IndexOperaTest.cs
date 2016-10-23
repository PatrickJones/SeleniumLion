using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.IO;

namespace SeleniumLion.Tests.Views
{
    [TestClass]
    public class IndexOperaTest : BaseUnitTest
    {
        public IndexOperaTest()
        {

        }

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            //https://chocolatey.org/packages/selenium-opera-driver
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driverPath = Path.Combine(dir, "Drivers", "OperaDriver");
            OperaDriver = new OperaDriver(driverPath);
        }

            [TestMethod]
        public void TestOperaDriver()
        {
            OperaDriver.Navigate().GoToUrl("http://www.google.com/");
            IWebElement query = OperaDriver.FindElement(By.Id("lst-ib"));
            query.SendKeys("Selenium");
            query.Submit();

            var wait = new WebDriverWait(OperaDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("selenium", StringComparison.OrdinalIgnoreCase));

            System.Diagnostics.Debug.WriteLine($"Page title is: {OperaDriver.Title}");
        }

        [ClassCleanup()]
        public static void TestClassCleanup()
        {
            OperaDriver.Quit();
        }
    }
}
