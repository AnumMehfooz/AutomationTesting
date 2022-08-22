using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProject1
{
    [TestFixture]
    public class Tests : TestBase
    {
        [Test]
        public void verifyInvalidLogin()
        {
            driver.Url = "https://localhost:44307/";
            driver.FindElement(By.Id("Email")).SendKeys("Invalid@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("12343333");
            driver.FindElement(By.CssSelector(".col-xs-4")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void invalidPassword()
        {
            driver.Url = "https://localhost:44307/";
            driver.FindElement(By.Id("Email")).SendKeys("Owner12@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("12343333");
            driver.FindElement(By.CssSelector(".col-xs-4")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void verifyValidLogin()
        {
            AuthenticationTestCases auth = new AuthenticationTestCases();
            auth.Login(driver);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
    }
}
