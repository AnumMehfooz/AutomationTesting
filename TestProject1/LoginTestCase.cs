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
        public void verifyValidLogin()
        {
            AuthenticationTestCases auth = new AuthenticationTestCases();
            auth.Login(driver);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

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
            driver.FindElement(By.Id("Email")).SendKeys("Owner1@gmail.com");
            driver.FindElement(By.Id("Password")).SendKeys("12343333");
            driver.FindElement(By.CssSelector(".col-xs-4")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        //public void shelvingBinPage(IWebDriver driver)
        //{

        //    //var model = new Tests();
        //    //model?.verifyValidLogin();

        //    driver.Navigate().GoToUrl("https://localhost:44307/ShelvingBin");
        //    WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //}

        //public void TestAddBin(IWebDriver driver)
        //{
        //    driver.FindElement(By.XPath(".//*[@id='TreeGrid_add']")).Click();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
        //    SelectElement warehouseSelect = new SelectElement(driver.FindElement(By.XPath(".//*[@id='WarehouseId']")));
        //    warehouseSelect.SelectByIndex(1);

        //    IWebElement aisle = driver.FindElement(By.XPath(".//*[@id='Aisle']"));
        //    IWebElement bay = driver.FindElement(By.XPath(".//*[@id='Bay']"));
        //    IWebElement shelf = driver.FindElement(By.XPath(".//*[@id='Shelf']"));
        //    IWebElement bin = driver.FindElement(By.XPath(".//*[@id='Name']"));
        //    IWebElement width = driver.FindElement(By.XPath(".//*[@id='Width']"));
        //    IWebElement height = driver.FindElement(By.XPath(".//*[@id='Height']"));
        //    IWebElement depth = driver.FindElement(By.XPath(".//*[@id='Depth']"));

        //    aisle.SendKeys("22");
        //    bay.SendKeys("2");
        //    shelf.SendKeys("ku");
        //    bin.SendKeys("9r");
        //    width.Clear();
        //    width.SendKeys("9");
        //    height.Clear();
        //    height.SendKeys("2");
        //    depth.Clear();
        //    depth.SendKeys("1");

        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        //    driver.FindElement(By.XPath("(.//*[@class='e-control e-btn e-lib e-primary e-flat'])[2]")).Click();
        //}

        //public void TestEdit(IWebDriver driver)
        //{
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        //    //Actions act = new Actions(driver);

        //    //click on first row
        //    driver.FindElement(By.XPath("(.//*[@class='e-rowcell'])[1]")).Click();

        //    //click on edit button
        //    driver.FindElement(By.XPath(".//*[@id='TreeGrid_edit']")).Click();

        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    SelectElement warehouseSelect = new SelectElement(driver.FindElement(By.XPath(".//*[@id='WarehouseId']")));
        //    warehouseSelect.SelectByIndex(1);

        //    IWebElement aisle = driver.FindElement(By.XPath(".//*[@id='Aisle']"));
        //    IWebElement bay = driver.FindElement(By.XPath(".//*[@id='Bay']"));
        //    IWebElement shelf = driver.FindElement(By.XPath(".//*[@id='Shelf']"));
        //    IWebElement bin = driver.FindElement(By.XPath(".//*[@id='Name']"));
        //    IWebElement width = driver.FindElement(By.XPath(".//*[@id='Width']"));
        //    IWebElement height = driver.FindElement(By.XPath(".//*[@id='Height']"));
        //    IWebElement depth = driver.FindElement(By.XPath(".//*[@id='Depth']"));

        //    aisle.Clear();
        //    aisle.SendKeys("A1");
        //    bay.Clear();
        //    bay.SendKeys("V2");
        //    shelf.Clear();
        //    shelf.SendKeys("k3");
        //    bin.Clear();
        //    bin.SendKeys("B4");
        //    width.Clear();
        //    width.SendKeys("5");
        //    height.Clear();
        //    height.SendKeys("1");
        //    depth.Clear();
        //    depth.SendKeys("2");

        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        //    driver.FindElement(By.XPath("(.//*[@class='e-control e-btn e-lib e-primary e-flat'])[2]")).Click();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        //}

        //public void TestDelete(IWebDriver driver)
        //{
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        //    //click on first row
        //    driver.FindElement(By.XPath("(.//*[@class='e-rowcell'])[1]")).Click();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        //    //click on edit button
        //    driver.FindElement(By.XPath(".//*[@id='TreeGrid_delete']")).Click();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        //    driver.FindElement(By.XPath("(.//*[@class='e-control e-btn e-lib e-primary e-flat'])[1]")).Click();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        //}

        //public void TestDuplicate(IWebDriver driver)
        //{
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        //    driver.FindElement(By.XPath(".//*[@class='btn btn-info']")).Click();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        //}

        //public void TestPrint(IWebDriver driver)
        //{

        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        //    driver.FindElement(By.LinkText("Print Bin Barcode(s)")).Click();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        //    driver.FindElement(By.LinkText("Download PDF")).Click();
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);


        //}
    }
}
