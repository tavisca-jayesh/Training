using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace seleniumEMS
{
    [TestClass]
    public class AddRemark
    {
        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void AddRemarkSuccess()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:62581/LoginPage.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl_UserId")).SendKeys("jy@g.c");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Password")).SendKeys("asdf123");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Submit")).Click();
            driver.FindElement(By.Id("MainContent_Employee")).Click();

            new SelectElement(driver.FindElement(By.Id("MainContent_AddRemarkUserControl1_EmployeeList"))).SelectByIndex(2);
            driver.FindElement(By.Id("MainContent_AddRemarkUserControl1_RemarkText")).SendKeys("This is a selenium remark");
            driver.FindElement(By.Id("MainContent_AddRemarkUserControl1_AddRemarkButton")).Click();

            var status = driver.FindElement(By.Id("MainContent_AddRemarkUserControl1_Success")).Displayed;
            Assert.IsTrue(status);
        }

        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void AddRemarkFailure()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:62581/LoginPage.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl_UserId")).SendKeys("jy@g.c");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Password")).SendKeys("asdf123");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Submit")).Click();
            driver.FindElement(By.Id("MainContent_Employee")).Click();

            new SelectElement(driver.FindElement(By.Id("MainContent_AddRemarkUserControl1_EmployeeList"))).SelectByIndex(2);
            driver.FindElement(By.Id("MainContent_AddRemarkUserControl1_RemarkText")).SendKeys("This is a selenium remark");
            driver.FindElement(By.Id("MainContent_AddRemarkUserControl1_AddRemarkButton")).Click();

            var status = driver.FindElement(By.Id("MainContent_AddRemarkUserControl1_Failure")).Displayed;
            Assert.IsTrue(status);
        }
    }
}
