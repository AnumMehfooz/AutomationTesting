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
    public class shelvingBin : TestBase
    {

        [Test]

        public void Home()
        {
            try
            {
               AuthenticationTestCases auth = new AuthenticationTestCases();
               auth.Login(driver);
            }
            catch (WebDriverException) { }

            shelvingBinPage(driver);
            TestAddBin(driver);
            shelvingBinPage(driver);
            TestEdit(driver);
            TestDelete(driver);
            TestDuplicate(driver);
            TestPrint(driver);
            shelvingBinPage(driver);

        }
        public void shelvingBinPage(IWebDriver driver)
        {
            try
            {
                driver.Navigate().GoToUrl("https://localhost:44307/ShelvingBin");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            }
            catch(WebDriverException) { }
            //new WebDriverWait(driver, TimeSpan.FromSeconds(40)).Until(driver => driver.FindElement(By.XPath(".//html//body//div[1]//div//section//div//div")));
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(driver => driver.FindElement(By.XPath(".//*[@id='TreeGrid_content_table']//tbody//tr//td[1]//button")));

        }

        public void TestAddBin(IWebDriver driver)
        {
            try
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(40)).Until(driver => driver.FindElement(By.XPath(".//*[@id='TreeGrid_content_table']//tbody//tr//td[1]//button")));
                driver.FindElement(By.XPath(".//*[@id='TreeGrid_add']//span[2]")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                SelectElement warehouseSelect = new SelectElement(driver.FindElement(By.XPath(".//*[@id='WarehouseId']")));
                warehouseSelect.SelectByIndex(0);

                IWebElement aisle = driver.FindElement(By.XPath(".//*[@id='Aisle']"));
                IWebElement bay = driver.FindElement(By.XPath(".//*[@id='Bay']"));
                IWebElement shelf = driver.FindElement(By.XPath(".//*[@id='Shelf']"));
                IWebElement bin = driver.FindElement(By.XPath(".//*[@id='Name']"));
                IWebElement width = driver.FindElement(By.XPath(".//*[@id='Width']"));
                IWebElement height = driver.FindElement(By.XPath(".//*[@id='Height']"));
                IWebElement depth = driver.FindElement(By.XPath(".//*[@id='Depth']"));

                RandomStringIntValues randomStringIntValues = new RandomStringIntValues();
                aisle.SendKeys(randomStringIntValues.RandomString(2, true));
                bay.SendKeys(randomStringIntValues.RandomString(2, true));
                bin.SendKeys(randomStringIntValues.RandomString(2, true));

                width.Clear();
                width.SendKeys("2");
                height.Clear();
                height.SendKeys("2");
                depth.Clear();
                depth.SendKeys("1");

                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.FindElement(By.XPath("(.//*[@class='e-control e-btn e-lib e-primary e-flat'])[2]")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            }
            catch (WebDriverException) { }

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

            RandomStringIntValues randomStringIntValues = new RandomStringIntValues();
            aisle.Clear();
            aisle.SendKeys(randomStringIntValues.RandomString(2, true));
            bay.Clear();
            bay.SendKeys(randomStringIntValues.RandomString(2, true));
            shelf.Clear();
            shelf.SendKeys(randomStringIntValues.RandomString(2, true));
            bin.Clear();
            bin.SendKeys(randomStringIntValues.RandomString(2, true));
            width.Clear();
            width.SendKeys("2");
            height.Clear();
            height.SendKeys("2");
            depth.Clear();
            depth.SendKeys("2");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.FindElement(By.XPath("(.//*[@class='e-control e-btn e-lib e-primary e-flat'])[2]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        }

        public void TestDelete(IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.FindElement(By.XPath(".//*[@id='TreeGrid_content_table']//tbody//tr[2]//td[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.FindElement(By.XPath(".//*[@id='TreeGrid_delete']")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.FindElement(By.XPath("(.//*[@class='e-control e-btn e-lib e-primary e-flat'])[1]")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

            driver.Navigate().Refresh();
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
            driver.FindElement(By.XPath("//*[@id='printBarcodes']")).Click();

            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(driver => driver.Url.Equals("https://localhost:44307/ShelvingBin/PrintBarcodes"));

            driver.Navigate().Back();
            new WebDriverWait(driver, TimeSpan.FromSeconds(20)).Until(driver => driver.FindElement(By.XPath(".//*[@class='btn btn-info']")));
        }
    }
}
