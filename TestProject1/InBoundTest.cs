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
            //DetailsPage(driver);
        }
        public void InBoundPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl("https://localhost:44307/Inbound");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        public void AddInbound(IWebDriver driver)
        {
            RandomStringIntValues randomStringIntValues = new RandomStringIntValues();
            //randomStringIntValues.RandomString(1,true);

            new WebDriverWait(driver, TimeSpan.FromSeconds(40)).Until(driver => driver.FindElement(By.XPath(".//html//body//div[1]//div//section//div//div")));
            driver.FindElement(By.XPath(".//*[@id='TreeGrid_add']/span[2]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            SelectElement sellerName = new SelectElement(driver.FindElement(By.XPath(".//*[@id='UserId']")));
            sellerName.SelectByIndex(2);

            IWebElement masterCartonsNumber = driver.FindElement(By.Id("MasterCartonsNumber"));
            IWebElement personInCharge = driver.FindElement(By.Id("PersonInChargeSeller"));
            IWebElement dispatchDate = driver.FindElement(By.Name("DispatchDate"));
            IWebElement arivalDate = driver.FindElement(By.Name("ArrivalDate"));
            IWebElement proofingPictures = driver.FindElement(By.XPath(".//*[@id='ProofingPicturePicker']"));

            //Call the method
            //String s1 = RandomString(4, true);
            //Pass value to an element
            //element.sendkeys(s1);

            masterCartonsNumber.SendKeys( randomStringIntValues.RandomString(6, true));
            //masterCartonsNumber.SendKeys("2dq");
            dispatchDate.Clear();
            dispatchDate.SendKeys("08/23/2022");
            arivalDate.Clear();
            arivalDate.SendKeys("08/28/2022");
            proofingPictures.SendKeys("C:\\Users\\DREAM-BEYOND\\Pictures\\Saved Pictures\\icon.png");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.FindElement(By.XPath("//*[@id='TreeGrid_dialogEdit_wrapper']//div[3]//button[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        //public void DetailsPage(IWebDriver driver)
        //{
        //    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.FindElement(By.XPath(".//html//body//div[1]//div//section//div//div")));
        //    var accept = driver.FindElement(By.XPath("//*[@id='TreeGrid_content_table']//tbody//tr[7]//td[2]//div//button[1]"));
        //    if (accept != null)
        //    {
        //        driver.FindElement(By.XPath("//*[@id='TreeGrid_content_table']//tbody//tr[7]//td[3]//a")).Click();
        //        AddSingleProduct(driver);
        //    }

            //}
            //public void AddSingleProduct(IWebDriver driver)
            //{
            //    new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(driver => driver.FindElement(By.XPath(".//html//body//div[1]//div//section[2]")));
            //    driver.FindElement(By.XPath("//*[@id='LineItems_add']//span[2]")).Click();
            //    //driver.FindElement(By.XPath("//*[@id='LineItems_content_table']/tbody/tr/td[1]"));

            //    SelectElement products = new SelectElement(driver.FindElement(By.XPath("//*[@id='LineItemsEditForm']/span")));
            //    products.SelectByIndex(0);

            //    IWebElement AddQuantity =  driver.FindElement(By.XPath("//*[@id='LineItems_content_table']//tbody//tr//td[2]"));
            //    AddQuantity.SendKeys()

            //}
        }
}
