using PlataformaComercio.Business.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PlataformaComercio.TestProject
{
    
    
    /// <summary>
    ///This is a test class for EmailSendConfigTest and is intended
    ///to contain all EmailSendConfigTest Unit Tests
    ///</summary>
    [TestClass()]
    public class EmailSendConfigTest
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
        ///A test for EmailSendConfig Constructor
        ///</summary>
        [TestMethod()]
        public void EmailSendConfigConstructorTest()
        {
            EmailSendConfig target = new EmailSendConfig();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for From
        ///</summary>
        [TestMethod()]
        public void FromTest()
        {
            EmailSendConfig target = new EmailSendConfig(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.From = expected;
            actual = target.From;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for IsBodyHtml
        ///</summary>
        [TestMethod()]
        public void IsBodyHtmlTest()
        {
            EmailSendConfig target = new EmailSendConfig(); // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            target.IsBodyHtml = expected;
            actual = target.IsBodyHtml;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Subjet
        ///</summary>
        [TestMethod()]
        public void SubjetTest()
        {
            EmailSendConfig target = new EmailSendConfig(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.Subjet = expected;
            actual = target.Subjet;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TO
        ///</summary>
        [TestMethod()]
        public void TOTest()
        {
            EmailSendConfig target = new EmailSendConfig(); // TODO: Initialize to an appropriate value
            string expected = string.Empty; // TODO: Initialize to an appropriate value
            string actual;
            target.TO = expected;
            actual = target.TO;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Template
        ///</summary>
        [TestMethod()]
        public void TemplateTest()
        {
            EmailSendConfig target = new EmailSendConfig(); // TODO: Initialize to an appropriate value
            EmailSendTemplate expected = new EmailSendTemplate(); // TODO: Initialize to an appropriate value
            EmailSendTemplate actual;
            target.Template = expected;
            actual = target.Template;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
