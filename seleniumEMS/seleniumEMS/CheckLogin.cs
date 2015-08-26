using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


namespace seleniumEMS
{
    [TestClass]
    public class CheckLogin
    {
        [TestMethod]
        [ExpectedException(typeof(OpenQA.Selenium.NoSuchElementException))]
        public void CheckLoginSuccess()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:62581/LoginPage.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl_UserId")).SendKeys("ab@g.c");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Password")).SendKeys("asdf123");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Submit")).Click();

            var status = driver.FindElement(By.Id("MainContent_LoginUserControl_Failure")).Displayed;
        }

        [TestMethod]
        public void CheckLoginFailure()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:62581/LoginPage.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl_UserId")).SendKeys("ab@g.c");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Password")).SendKeys("qwerrt123");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Submit")).Click();

            var status = driver.FindElement(By.Id("MainContent_LoginUserControl_Failure")).Displayed;
            Assert.IsTrue(status);
        }
    }
}
