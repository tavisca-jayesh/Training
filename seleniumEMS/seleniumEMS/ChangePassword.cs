using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace seleniumEMS
{
    [TestClass]
    public class ChangePassword
    {
        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void ChangePasswordSuccess()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:62581/LoginPage.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl_UserId")).SendKeys("as@d.f");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Password")).SendKeys("asdf123");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Submit")).Click();

            driver.FindElement(By.Id("MainContent_ChangePassword1_ChangePasswordContainerID_CurrentPassword")).SendKeys("asdf123");
            driver.FindElement(By.Id("MainContent_ChangePassword1_ChangePasswordContainerID_NewPassword")).SendKeys("qwert12");
            driver.FindElement(By.Id("MainContent_ChangePassword1_ChangePasswordContainerID_ConfirmNewPassword")).SendKeys("qwert12");

            driver.FindElement(By.Id("MainContent_ChangePassword1_ChangePasswordContainerID_ChangePasswordPushButton")).Click();

            var status = driver.FindElement(By.Id("MainContent_ChangePassword1_ChangePasswordTemplateContainer")).Displayed;
            Assert.IsFalse(status);
        }
    }
}
