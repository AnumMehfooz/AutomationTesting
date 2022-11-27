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
            driver.Url = "https://stacketpro-staging.azurewebsites.net/Account/Login";
            driver.FindElement(By.Id("Email")).SendKeys("owais.afsar@outlook.com");
            driver.FindElement(By.Id("Password")).SendKeys("123456");
            try
            {
                 driver.FindElement(By.CssSelector(".button")).Click();
            }
            catch (WebDriverException) { }
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.Url.Equals("https://stacketpro-staging.azurewebsites.net/Account/Login"));
            try
            {
                driver.FindElement(By.XPath(".//html//body//div[6]//div//div[1]//a")).Click();
            }
            catch (WebDriverException) { }


        }

    }
}
