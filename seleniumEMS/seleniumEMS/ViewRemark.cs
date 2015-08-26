using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace seleniumEMS
{
    [TestClass]
    public class ViewRemark
    {
        [TestMethod]
        public void ViewRemarkSuccess()
        {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.Navigate().GoToUrl("http://localhost:62581/LoginPage.aspx");
            driver.FindElement(By.Id("MainContent_LoginUserControl_UserId")).SendKeys("as@d.f");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Password")).SendKeys("asdf123");
            driver.FindElement(By.Id("MainContent_LoginUserControl_Submit")).Click();

            var status = driver.FindElement(By.Id("FeaturedContent_GridView1")).Displayed;
            Assert.IsTrue(status);
        }
    }
}
