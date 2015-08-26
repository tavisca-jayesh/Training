using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeRemarkApp.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Net;
using System.Configuration;
using System.Data.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace seleniumEMS
{
    [TestClass]
    public class AddEmployee
    {
        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void AddEmployeeSuccess()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:62581/LoginPage.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl_UserId")).SendKeys("jy@g.c");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Password")).SendKeys("asdf123");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Submit")).Click();

            driver.FindElement(By.Id("MainContent_AddEmployeeUserControl1_FirstNameBox")).SendKeys("first");
            driver.FindElement(By.Id("MainContent_AddEmployeeUserControl1_TitleBox")).SendKeys("MR");
            driver.FindElement(By.Id("MainContent_AddEmployeeUserControl1_LastNameBox")).SendKeys("last");
            driver.FindElement(By.Id("MainContent_AddEmployeeUserControl1_EmailBox")).SendKeys("email@g.c");
            driver.FindElement(By.Id("MainContent_AddEmployeeUserControl1_PhoneBox")).SendKeys("9875462130");

            driver.FindElement(By.Id("MainContent_AddEmployeeUserControl1_EmpSubmitButton")).Click();

            var status = driver.FindElement(By.Id("MainContent_AddEmployeeUserControl1_Success")).Displayed;
            Assert.IsTrue(status);
        }

        [TestMethod]
        public void AddEmployeeFailure()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:62581/LoginPage.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl_UserId")).SendKeys("jy@g.c");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Password")).SendKeys("asdf123");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Submit")).Click();

            driver.FindElement(By.Id("MainContent_AddEmployeeUserControl1_FirstNameBox")).SendKeys("first");
            driver.FindElement(By.Id("MainContent_AddEmployeeUserControl1_TitleBox")).SendKeys("MR");
            driver.FindElement(By.Id("MainContent_AddEmployeeUserControl1_LastNameBox")).SendKeys("last");
            driver.FindElement(By.Id("MainContent_AddEmployeeUserControl1_EmailBox")).SendKeys("email@g.c");
            driver.FindElement(By.Id("MainContent_AddEmployeeUserControl1_PhoneBox")).SendKeys("abbra112233");

            driver.FindElement(By.Id("MainContent_AddEmployeeUserControl1_EmpSubmitButton")).Click();

            var status = driver.FindElement(By.Id("MainContent_AddEmployeeUserControl1_Failure")).Displayed;
            Assert.IsTrue(status);
        }

    }
}
