using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System.IO;
using System.Reflection;

namespace SeleniumLion.Tests.Views
{
    /// <summary>
    /// Summary description for IndexTest
    /// </summary>
    [TestClass]
    public class IndexChromeTest : BaseUnitTest
    {
        public IndexChromeTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driverPath = Path.Combine(dir, "Drivers", "chromedriver_win32");
            ChromeDriver = new ChromeDriver(driverPath);
        }


        [TestMethod]
        public void TestChromeDriver()
        {
            ChromeDriver.Navigate().GoToUrl("http://www.google.com/");
            IWebElement query = ChromeDriver.FindElement(By.Id("lst-ib"));
            query.SendKeys("Selenium");
            query.Submit();

            var wait = new WebDriverWait(ChromeDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("selenium", StringComparison.OrdinalIgnoreCase));

            System.Diagnostics.Debug.WriteLine($"Page title is: {ChromeDriver.Title}");
        }

        [TestMethod]
        public void TestReserveCreation()
        {
            ChromeDriver.Navigate().GoToUrl("http://localhost:61099/Reserves/Create");
            IWebElement formName = ChromeDriver.FindElement(By.Id("Name"));
            formName.SendKeys("Kalahari");
            IWebElement formLocation = ChromeDriver.FindElement(By.Id("Location"));
            formLocation.SendKeys("Africa");

            IWebElement formSubmit = ChromeDriver.FindElement(By.Id("submit-reserve"));
            formSubmit.Submit();

        }

        [ClassCleanup()]
        public static void TestClassCleanup()
        {
            ChromeDriver.Quit();
        }
    }
}
