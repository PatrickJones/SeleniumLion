using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumLion.Tests.Views
{
    /// <summary>
    /// Summary description for IndexFirefoxTest
    /// </summary>
    [TestClass]
    public class IndexFirefoxTest : BaseUnitTest
    {

        public IndexFirefoxTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            FirefoxDriver = new FirefoxDriver();
        }

        [TestMethod]
        public void TestFireFoxDriver()
        {
            FirefoxDriver.Navigate().GoToUrl("http://www.google.com/");
            IWebElement query = FirefoxDriver.FindElement(By.Id("lst-ib"));
            query.SendKeys("Selenium");
            query.Submit();

            var wait = new WebDriverWait(FirefoxDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("selenium", StringComparison.OrdinalIgnoreCase));
            //driverFireFox.FindElement(By.Id("searchText")).SendKeys(Keys.Enter);

            Console.WriteLine($"Page title is: {FirefoxDriver.Title}");
        }
    }
}
