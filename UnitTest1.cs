using System;
using System.Collections.ObjectModel;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V85.Debugger;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace RestService
{
    [TestClass]
    public class UnitTestAnother
    {
        private static readonly string DriverDirectory = "C:\\webDrivers";
        private static IWebDriver _driver; 

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            _driver = new ChromeDriver(DriverDirectory);
        }

        [ClassCleanup]
        public static void TearDown()
        {
            _driver.Dispose();
        }

        [TestMethod]
        public void TestMethod1()
        {
            string url = "http://127.0.0.1:5500/index.html";
            _driver.Navigate().GoToUrl(url);

            string title = _driver.Title;
            Assert.AreEqual("Water Flow app", title);

            Thread.Sleep(2000);
            ReadOnlyCollection<IWebElement> listElements = _driver.FindElements(By.TagName("tr"));

            Assert.AreEqual(7, listElements.Count);

            int firstCount = listElements.Count;
            Assert.IsTrue(listElements[1].Text.Contains("AddItWater"));

            _driver.FindElement(By.Id("id")).Clear();
            _driver.FindElement(By.Id("id")).SendKeys("2");
            _driver.FindElement(By.Id("name")).SendKeys("FilterWater");
            _driver.FindElement(By.Id("volume")).Clear();
            _driver.FindElement(By.Id("volume")).SendKeys("5");
            _driver.FindElement(By.Id("addButton")).Click();

            Thread.Sleep(5000);
            listElements = _driver.FindElements(By.TagName("tr"));
            Assert.AreEqual(firstCount + 1, listElements.Count);

        }
    }
}
