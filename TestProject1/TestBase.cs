using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    public class TestBase
    {
        public IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver();       // Launches browser
            driver.Manage().Window.Maximize(); //Maximizes browser
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(70); //Set locator timeout to be 20s at max
        }

        //[OneTimeTearDown]
        //public void cleanUp()
        //{
        //    driver.Quit();
        //}
    }
}
