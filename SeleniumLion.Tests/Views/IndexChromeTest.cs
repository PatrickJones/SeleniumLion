using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLion.Tests.Views
{
    /// <summary>
    /// Summary description for IndexTest
    /// </summary>
    [TestClass]
    public class IndexChromeTest : BaseUnitTest
    {
        //static IWebDriver driverChrome;
        //static IWebDriver driverFireFox;
        //static IWebDriver driverIE;

        public IndexChromeTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        //private TestContext testContextInstance;

        ///// <summary>
        /////Gets or sets the test context which provides
        /////information about and functionality for the current test run.
        /////</summary>
        //public TestContext TestContext
        //{
        //    get
        //    {
        //        return testContextInstance;
        //    }
        //    set
        //    {
        //        testContextInstance = value;
        //    }
        //}

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            //driverFireFox = new FirefoxDriver();
            ChromeDriver = new ChromeDriver(@"C:\SeleniumDrivers\chromedriver_win32");
            //driverIE = new InternetExplorerDriver();
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
            //driverFireFox.FindElement(By.Id("searchText")).SendKeys(Keys.Enter);

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
    }
}
