using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Selenium;


namespace SeleniumTests
{
    [TestClass]
    public class TestSelectmemberFromGrid
    {
        private ISelenium selenium;
        private StringBuilder verificationErrors;

        [TestInitialize]
        public void SetupTest()
        {
            selenium = new DefaultSelenium("localhost", 4444, "*chrome", "http://localhost:1125/");
            selenium.Start();
            verificationErrors = new StringBuilder();
        }

        [TestCleanup]
        public void TeardownTest()
        {
            try
            {
                selenium.Stop();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [TestMethod]
        public void TestLoginToAdminAndShowMembers()
        {
            selenium.Open("/");
            selenium.Click("id=LoginView1_adminLink");
            selenium.WaitForPageToLoad("30000");
            selenium.Type("id=MainContent_LoginControl_UserName", "adminuser");
            selenium.SelectWindow("null");
            selenium.Type("id=MainContent_LoginControl_Password", "");
            selenium.Type("id=MainContent_LoginControl_Password", "adminuser");
            selenium.Click("name=ctl00$MainContent$LoginControl$ctl06");
            selenium.WaitForPageToLoad("30000");
            selenium.Click("link=Miembros");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("adminuser", selenium.GetValue("id=cpMainContent_txbxUserName-inputEl"));
        }

        [TestMethod]
        public void TestSelectMemberFromGrid()
        {
            selenium.Open("/");
            selenium.Click("id=LoginView1_adminLink");
            selenium.WaitForPageToLoad("30000");
            selenium.Type("id=MainContent_LoginControl_UserName", "adminuser");
            selenium.SelectWindow("null");
            selenium.Type("id=MainContent_LoginControl_Password", "");
            selenium.Type("id=MainContent_LoginControl_Password", "adminuser");
            selenium.Click("name=ctl00$MainContent$LoginControl$ctl06");
            selenium.WaitForPageToLoad("30000");
            selenium.Click("link=Miembros");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("adminuser", selenium.GetValue("id=cpMainContent_txbxUserName-inputEl"));
            selenium.ClickAt("css=#ext-gen1359 > div.x-grid-cell-inner.", "mmar");
            selenium.WaitForPageToLoad("30000");
            Assert.AreEqual("mmar", selenium.GetValue("id=cpMainContent_txbxUserName-inputEl"));
        }
    }
}

