using PlataformaComercio.Business.Catalogs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PlataformaComercio.Entities.Inventory;

namespace PlataformaComercio.TestProject
{
    
    
    /// <summary>
    ///This is a test class for ProductTest and is intended
    ///to contain all ProductTest Unit Tests
    ///</summary>
    [TestClass()]
    public class ProductTest
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
        ///A test for Product Constructor
        ///</summary>
        [TestMethod()]
        public void ProductConstructorTest()
        {
            Product target = new Product();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            Product target = new Product(); // TODO: Initialize to an appropriate value
            EntProduct product = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Add(product);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            Product target = new Product(); // TODO: Initialize to an appropriate value
            string productID = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Delete(productID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAll
        ///</summary>
        [TestMethod()]
        public void GetAllTest()
        {
            Product target = new Product(); // TODO: Initialize to an appropriate value
            EntProduct[] expected = null; // TODO: Initialize to an appropriate value
            EntProduct[] actual;
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
            Product target = new Product(); // TODO: Initialize to an appropriate value
            string productID = string.Empty; // TODO: Initialize to an appropriate value
            EntProduct expected = null; // TODO: Initialize to an appropriate value
            EntProduct actual;
            actual = target.GetByID(productID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Update
        ///</summary>
        [TestMethod()]
        public void UpdateTest()
        {
            Product target = new Product(); // TODO: Initialize to an appropriate value
            EntProduct product = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Update(product);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ValidateProduct
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PlataformaComercio.Business.dll")]
        public void ValidateProductTest()
        {
            EntProduct product = null; // TODO: Initialize to an appropriate value
            Product_Accessor.ValidateProduct(product);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
