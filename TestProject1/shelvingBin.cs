﻿using NUnit.Framework;
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
    public class shelvingBin : TestBase
    {

        [Test]

        public void Home()
        {
            AuthenticationTestCases auth = new AuthenticationTestCases();
            auth.Login(driver);

            shelvingBinPage(driver, "Launch");

            TestAddBin(driver);
            shelvingBinPage(driver, "Add");

            TestEdit(driver);
            shelvingBinPage(driver, "Edit");

            TestDelete(driver);
            shelvingBinPage(driver, "Delete");

            TestDuplicate(driver);
            shelvingBinPage(driver, "Duplicate");

            TestPrint(driver);
            shelvingBinPage(driver, "Print");

        }
        public void shelvingBinPage(IWebDriver driver, string type)
        {
            driver.Navigate().GoToUrl("https://localhost:44307/ShelvingBin");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
        }

        public void TestAddBin(IWebDriver driver)
        {
            driver.FindElement(By.XPath(".//*[@id='TreeGrid_add']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            SelectElement warehouseSelect = new SelectElement(driver.FindElement(By.XPath(".//*[@id='WarehouseId']")));
            warehouseSelect.SelectByIndex(1);

            IWebElement aisle = driver.FindElement(By.XPath(".//*[@id='Aisle']"));
            IWebElement bay = driver.FindElement(By.XPath(".//*[@id='Bay']"));
            IWebElement shelf = driver.FindElement(By.XPath(".//*[@id='Shelf']"));
            IWebElement bin = driver.FindElement(By.XPath(".//*[@id='Name']"));
            IWebElement width = driver.FindElement(By.XPath(".//*[@id='Width']"));
            IWebElement height = driver.FindElement(By.XPath(".//*[@id='Height']"));
            IWebElement depth = driver.FindElement(By.XPath(".//*[@id='Depth']"));

            aisle.SendKeys("22");
            bay.SendKeys("2");
            shelf.SendKeys("ku");
            bin.SendKeys("9r");
            width.Clear();
            width.SendKeys("9");
            height.Clear();
            height.SendKeys("2");
            depth.Clear();
            depth.SendKeys("1");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("(.//*[@class='e-control e-btn e-lib e-primary e-flat'])[2]")).Click();
        }

        public void TestEdit(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //click on first row
            driver.FindElement(By.XPath("(.//*[@class='e-rowcell'])[1]")).Click();

            //click on edit button
            driver.FindElement(By.XPath(".//*[@id='TreeGrid_edit']")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            SelectElement warehouseSelect = new SelectElement(driver.FindElement(By.XPath(".//*[@id='WarehouseId']")));
            warehouseSelect.SelectByIndex(1);

            IWebElement aisle = driver.FindElement(By.XPath(".//*[@id='Aisle']"));
            IWebElement bay = driver.FindElement(By.XPath(".//*[@id='Bay']"));
            IWebElement shelf = driver.FindElement(By.XPath(".//*[@id='Shelf']"));
            IWebElement bin = driver.FindElement(By.XPath(".//*[@id='Name']"));
            IWebElement width = driver.FindElement(By.XPath(".//*[@id='Width']"));
            IWebElement height = driver.FindElement(By.XPath(".//*[@id='Height']"));
            IWebElement depth = driver.FindElement(By.XPath(".//*[@id='Depth']"));

            aisle.Clear();
            aisle.SendKeys("A1");
            bay.Clear();
            bay.SendKeys("V2");
            shelf.Clear();
            shelf.SendKeys("k3");
            bin.Clear();
            bin.SendKeys("B4");
            width.Clear();
            width.SendKeys("5");
            height.Clear();
            height.SendKeys("1");
            depth.Clear();
            depth.SendKeys("2");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("(.//*[@class='e-control e-btn e-lib e-primary e-flat'])[2]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        public void TestDelete(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //click on first row
            driver.FindElement(By.XPath("(.//*[@class='e-rowcell'])[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            //click on edit button
            driver.FindElement(By.XPath(".//*[@id='TreeGrid_delete']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.FindElement(By.XPath("(.//*[@class='e-control e-btn e-lib e-primary e-flat'])[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public void TestDuplicate(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.FindElement(By.XPath(".//*[@class='btn btn-info']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }

        public void TestPrint(IWebDriver driver)
        {

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.LinkText("Print Bin Barcode(s)")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
            driver.FindElement(By.LinkText("Download PDF")).Click();
            
            new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(driver => driver.Url.Equals("https://localhost:44307/ShelvingBin/PrintBarcodes"));

        }
    }
}