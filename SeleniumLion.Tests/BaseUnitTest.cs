using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace SeleniumLion.Tests
{
    /// <summary>
    /// Summary description for BaseUnitTest
    /// </summary>
    [TestClass]
    public class BaseUnitTest
    {
        public BaseUnitTest()
        {
            
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        //https://addons.mozilla.org/en-US/firefox/addon/selenium-ide/
        // Not working until Selenium signs the version of the plugin
        public static IWebDriver FirefoxDriver { get; set; }
        public static IWebDriver ChromeDriver { get; set; }
        public static IWebDriver IEDriver { get; set; }
        public static IWebDriver OperaDriver { get; set; }

    }
}
