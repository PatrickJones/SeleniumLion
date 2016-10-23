using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

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
            OperaDriver = new OperaDriver(@"C:\SeleniumDrivers\OperaDriver");
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
            //driverFireFox.FindElement(By.Id("searchText")).SendKeys(Keys.Enter);

            System.Diagnostics.Debug.WriteLine($"Page title is: {OperaDriver.Title}");
        }
    }
}
