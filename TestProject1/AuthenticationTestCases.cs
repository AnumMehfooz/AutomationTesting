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
            driver.FindElement(By.Id("Email")).SendKeys("Owner1@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            try
            {
                 driver.FindElement(By.CssSelector(".button")).Click();
            }
            catch (WebDriverException) { }
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url.Equals("https://localhost:44307/"));
            try
            {
                driver.FindElement(By.XPath(".//*[@class='introjs-skipbutton']")).Click();
            }
            catch (WebDriverException) { }


        }

    }
}
