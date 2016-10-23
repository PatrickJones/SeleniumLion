using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.IE;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Reflection;
using System.IO;

namespace SeleniumLion.Tests.Views
{
    [TestClass]
    public class IndexIETest : BaseUnitTest
    {
        public IndexIETest()
        {

        }

        [ClassInitialize]
        public static void Initialize(TestContext testContext)
        {
            //http://selenium-release.storage.googleapis.com/index.html?path=2.53/
            // Protected Mode must be consistent across all zones 

            var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var driverPath = Path.Combine(dir, "Drivers", "IEDriverServer_x64_2.53.1");
            IEDriver = new InternetExplorerDriver(driverPath);
        }


        [TestMethod]
        public void TestIEDriver()
        {
            IEDriver.Navigate().GoToUrl("http://www.google.com/");
            IWebElement query = IEDriver.FindElement(By.Id("lst-ib"));
            query.SendKeys("Selenium");
            query.Submit();

            var wait = new WebDriverWait(IEDriver, TimeSpan.FromSeconds(10));
            wait.Until(d => d.Title.StartsWith("selenium", StringComparison.OrdinalIgnoreCase));

            System.Diagnostics.Debug.WriteLine($"Page title is: {IEDriver.Title}");
        }

        [ClassCleanup()]
        public static void TestClassCleanup()
        {
            IEDriver.Quit();
        }
    }
}
