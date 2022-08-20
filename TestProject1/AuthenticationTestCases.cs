using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    internal class AuthenticationTestCases
    {
        public void Login(IWebDriver driver)
        {
            driver.Url = "https://localhost:44307/";
            driver.FindElement(By.Id("Email")).SendKeys("Owner12@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            driver.FindElement(By.CssSelector(".col-xs-4")).Click();
            driver.FindElement(By.XPath(".//*[@id='introjs-dontShowAgain']")).Click();
            
        }

    }
}
