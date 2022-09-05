using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject1
{
    [TestFixture]
    public class BranchTest : TestBase
    {
        [Test]
        public void SetUp()
        {
            try
            {
                AuthenticationTestCases auth = new AuthenticationTestCases();
                auth.Login(driver);
            }
            catch (WebDriverException) { }

            Branch(driver);
            AddBranch(driver);
        }

        public void Branch(IWebDriver driver)


        {
            driver.Navigate().GoToUrl("https://stacketpro-staging.azurewebsites.net/Branch");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            new WebDriverWait(driver, TimeSpan.FromSeconds(3)).Until(driver => driver.FindElement(By.XPath(".//html//body//div[1]//aside//div//section//ul//li[3]//a//span")));
        } 

        public void AddBranch(IWebDriver driver)
        {


            driver.FindElement(By.Id("TreeGrid_add")).Click();
            driver.FindElement(By.Id("branchName")).SendKeys("XYZ");
            driver.FindElement(By.Id("BranchCode")).SendKeys("12323");
            driver.FindElement(By.Id("Street1")).SendKeys("Gulshan");
            driver.FindElement(By.Id("City")).SendKeys("Karachi");
            driver.FindElement(By.Id("State")).SendKeys("Sindh");
            driver.FindElement(By.Id("Country")).SendKeys("Pakistan");
            driver.FindElement(By.Id("ZipCode")).SendKeys("98783");

            //click on save button

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath(".//*[@id='TreeGrid_dialogEdit_wrapper']/div[3]/button[1]")).Click();

        }

        public void EditBranch(IWebDriver driver)
        {
            //selecting column

            driver.FindElement(By.XPath(".//*[@id='TreeGrid_content_table']/tbody/tr[2]/td[3]")).Click();
            driver.FindElement(By.Id("TreeGrid_edit")).Click();

            IWebElement Branch = driver.FindElement(By.Id("branchName"));
            IWebElement Code = driver.FindElement(By.Id("BranchCode"));
            IWebElement Address = driver.FindElement(By.Id("Street1"));
            IWebElement City = driver.FindElement(By.Id("City"));
            IWebElement State = driver.FindElement(By.Id("State"));
            IWebElement Country = driver.FindElement(By.Id("Country"));
            IWebElement ZipCode = driver.FindElement(By.Id("Zipcode"));


            Address.Clear();
            Address.SendKeys("Falak City Tower II Chundrigarh Road");
            ZipCode.Clear();
            ZipCode.SendKeys("990022");

            driver.FindElement(By.XPath(".//*[@id='TreeGrid_dialogEdit_wrapper']/div[3]/button[1]")).Click();


        }

    }


}
