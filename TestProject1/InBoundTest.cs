using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace TestProject1
{
    [TestFixture]
    public class InBoundTest : TestBase
    {
        [Test]
        public void Main()
        {
            AuthenticationTestCases auth = new AuthenticationTestCases();
            auth.Login(driver);

            InBoundPage(driver);
            AddInbound(driver);
        }
        public void InBoundPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://localhost:44307/Inbound");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public void AddInbound(IWebDriver driver)
        {
            driver.FindElement(By.XPath(".//*[@id='TreeGrid_add']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            SelectElement sellerName = new SelectElement(driver.FindElement(By.XPath(".//*[@id='UserId']")));
            sellerName.SelectByIndex(2);

            IWebElement masterCartonsNumber = driver.FindElement(By.Id("MasterCartonsNumber"));
            IWebElement personInCharge = driver.FindElement(By.Id("PersonInChargeSeller"));
            IWebElement dispatchDate = driver.FindElement(By.Name("DispatchDate"));
            IWebElement arivalDate = driver.FindElement(By.Name("ArrivalDate"));
            IWebElement proofingPictures = driver.FindElement(By.XPath(".//*[@id='ProofingPicturePicker']"));

            masterCartonsNumber.SendKeys("22");
            dispatchDate.Clear();
            dispatchDate.SendKeys("08/16/2022");
            arivalDate.Clear();
            arivalDate.SendKeys("08/16/2022");
            proofingPictures.SendKeys("C:\\Users\\DREAM-BEYOND\\Pictures\\Saved Pictures\\icon.png");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//*[@id='TreeGrid_dialogEdit_wrapper']//div[3]//button[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        //public void EditInbound(IWebDriver driver)
        //{
        //    driver.FindElement(By.XPath("(.//*[@class='e-rowcell'])[1]")).Click();
        //    if 
        //    driver.FindElement(By.XPath(".//*[@id='TreeGrid_edit']")).Click();
        //}
    }
}
