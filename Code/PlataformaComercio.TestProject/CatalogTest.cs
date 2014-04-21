using PlataformaComercio.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PlataformaComercio.Entities.Payment;
using PlataformaComercio.Entities.User;
using PlataformaComercio.Entities.Shipping;

namespace PlataformaComercio.TestProject
{
    
    
    /// <summary>
    ///This is a test class for CatalogTest and is intended
    ///to contain all CatalogTest Unit Tests
    ///</summary>
    [TestClass()]
    public class CatalogTest
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
        ///A test for GetShippingCost
        ///</summary>
        [TestMethod()]
        public void GetShippingCostTest()
        {
            Catalog target = new Catalog(); // TODO: Initialize to an appropriate value
            int shippingCostId = 0; // TODO: Initialize to an appropriate value
            Decimal expected = new Decimal(); // TODO: Initialize to an appropriate value
            Decimal actual;
            actual = target.GetShippingCost(shippingCostId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetPayment
        ///</summary>
        [TestMethod()]
        public void GetPaymentTest()
        {
            Catalog target = new Catalog(); // TODO: Initialize to an appropriate value
            int paymentId = 0; // TODO: Initialize to an appropriate value
            EntPayment expected = null; // TODO: Initialize to an appropriate value
            EntPayment actual;
            actual = target.GetPayment(paymentId);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetNeighborghoodsByZipCode
        ///</summary>
        [TestMethod()]
        public void GetNeighborghoodsByZipCodeTest()
        {
            Catalog target = new Catalog(); // TODO: Initialize to an appropriate value
            string zipCode = string.Empty; // TODO: Initialize to an appropriate value
            bool fillParentInfo = false; // TODO: Initialize to an appropriate value
            EntNeighborghood[] expected = null; // TODO: Initialize to an appropriate value
            EntNeighborghood[] actual;
            actual = target.GetNeighborghoodsByZipCode(zipCode, fillParentInfo);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetNeighborghoodByZipCodeAndId
        ///</summary>
        [TestMethod()]
        public void GetNeighborghoodByZipCodeAndIdTest()
        {
            Catalog target = new Catalog(); // TODO: Initialize to an appropriate value
            int neighborghoodId = 0; // TODO: Initialize to an appropriate value
            string zipCode = string.Empty; // TODO: Initialize to an appropriate value
            EntNeighborghood expected = null; // TODO: Initialize to an appropriate value
            EntNeighborghood actual;
            actual = target.GetNeighborghoodByZipCodeAndId(neighborghoodId, zipCode);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddSearchNotFound
        ///</summary>
        [TestMethod()]
        public void AddSearchNotFoundTest()
        {
            Catalog target = new Catalog(); // TODO: Initialize to an appropriate value
            string inventoryId = string.Empty; // TODO: Initialize to an appropriate value
            string searchString = string.Empty; // TODO: Initialize to an appropriate value
            target.AddSearchNotFound(inventoryId, searchString);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Catalog Constructor
        ///</summary>
        [TestMethod()]
        public void CatalogConstructorTest()
        {
            Catalog target = new Catalog();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for GetShippingMethod
        ///</summary>
        [TestMethod()]
        public void GetShippingMethodTest()
        {
            Catalog target = new Catalog(); // TODO: Initialize to an appropriate value
            int shippingMethod = 0; // TODO: Initialize to an appropriate value
            EntShippingMethod expected = null; // TODO: Initialize to an appropriate value
            EntShippingMethod actual;
            actual = target.GetShippingMethod(shippingMethod);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetShippingMethods
        ///</summary>
        [TestMethod()]
        public void GetShippingMethodsTest()
        {
            Catalog target = new Catalog(); // TODO: Initialize to an appropriate value
            string shippingCostKey = string.Empty; // TODO: Initialize to an appropriate value
            EntShippingMethod[] expected = null; // TODO: Initialize to an appropriate value
            EntShippingMethod[] actual;
            actual = target.GetShippingMethods(shippingCostKey);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
