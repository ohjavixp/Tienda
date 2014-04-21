using PlataformaComercio.Business.Catalogs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PlataformaComercio.Entities.UI;

namespace PlataformaComercio.TestProject
{
    
    
    /// <summary>
    ///This is a test class for SiteMapTest and is intended
    ///to contain all SiteMapTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SiteMapTest
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
        ///A test for SiteMap Constructor
        ///</summary>
        [TestMethod()]
        public void SiteMapConstructorTest()
        {
            SiteMap target = new SiteMap();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetAll
        ///</summary>
        [TestMethod()]
        public void GetAllTest()
        {
            SiteMap target = new SiteMap(); // TODO: Initialize to an appropriate value
            EntSiteMapUI[] expected = null; // TODO: Initialize to an appropriate value
            EntSiteMapUI[] actual;
            actual = target.GetAll();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
