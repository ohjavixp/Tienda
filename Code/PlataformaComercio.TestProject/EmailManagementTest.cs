using PlataformaComercio.Business.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Mail;

namespace PlataformaComercio.TestProject
{
    
    
    /// <summary>
    ///This is a test class for EmailManagementTest and is intended
    ///to contain all EmailManagementTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EmailManagementTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for EmailManagement Constructor
        ///</summary>
        [TestMethod()]
        public void EmailManagementConstructorTest()
        {
            EmailManagement target = new EmailManagement();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Send
        ///</summary>
        [TestMethod()]
        public void SendTest()
        {
            MailMessage message = null; // TODO: Initialize to an appropriate value
            EmailManagement.Send(message,2);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for SendEmailFromTemplate
        ///</summary>
        [TestMethod()]
        public void SendEmailFromTemplateTest()
        {
            EmailSendConfig config = null; // TODO: Initialize to an appropriate value
            string[] parametros = null; // TODO: Initialize to an appropriate value
            EmailManagement.SendEmailFromTemplate(config, parametros);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
