using PlataformaComercio.Business.Catalogs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PlataformaComercio.Entities.Catalog;

namespace PlataformaComercio.TestProject
{
    
    
    /// <summary>
    ///This is a test class for TradeTest and is intended
    ///to contain all TradeTest Unit Tests
    ///</summary>
    [TestClass()]
    public class TradeTest
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
        ///A test for Trade Constructor
        ///</summary>
        [TestMethod()]
        public void TradeConstructorTest()
        {
            Trade target = new Trade();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            Trade target = new Trade(); // TODO: Initialize to an appropriate value
            EntTrade entTrade = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.Add(entTrade);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAll
        ///</summary>
        [TestMethod()]
        public void GetAllTest()
        {
            Trade target = new Trade(); // TODO: Initialize to an appropriate value
            EntTrade[] expected = null; // TODO: Initialize to an appropriate value
            EntTrade[] actual;
            actual = target.GetAll();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetByID
        ///</summary>
        [TestMethod()]
        public void GetByIDTest()
        {
            Trade target = new Trade(); // TODO: Initialize to an appropriate value
            int tradeID = 0; // TODO: Initialize to an appropriate value
            EntTrade expected = null; // TODO: Initialize to an appropriate value
            EntTrade actual;
            actual = target.GetByID(tradeID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetByName
        ///</summary>
        [TestMethod()]
        public void GetByNameTest()
        {
            Trade target = new Trade(); // TODO: Initialize to an appropriate value
            string tradeName = string.Empty; // TODO: Initialize to an appropriate value
            EntTrade expected = null; // TODO: Initialize to an appropriate value
            EntTrade actual;
            actual = target.GetByName(tradeName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Trade target = new Trade(); // TODO: Initialize to an appropriate value
            EntTrade entTrade = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Update(entTrade);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
