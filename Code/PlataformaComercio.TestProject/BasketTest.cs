using PlataformaComercio.Business.BasketManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PlataformaComercio.TestProject
{
    
    
    /// <summary>
    ///This is a test class for BasketTest and is intended
    ///to contain all BasketTest Unit Tests
    ///</summary>
    [TestClass()]
    public class BasketTest
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
        ///A test for Basket Constructor
        ///</summary>
        [TestMethod()]
        public void BasketConstructorTest()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Basket target = new Basket(name);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Basket Constructor
        ///</summary>
        [TestMethod()]
        public void BasketConstructorTest1()
        {
            Guid basketId = new Guid(); // TODO: Initialize to an appropriate value
            Basket target = new Basket(basketId);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Basket Constructor
        ///</summary>
        [TestMethod()]
        public void BasketConstructorTest2()
        {
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Guid userID = new Guid(); // TODO: Initialize to an appropriate value
            Basket target = new Basket(name, userID);
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest()
        {
            Guid basketId = new Guid(); // TODO: Initialize to an appropriate value
            Basket target = new Basket(basketId); // TODO: Initialize to an appropriate value
            target.Delete();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for Delete
        ///</summary>
        [TestMethod()]
        public void DeleteTest1()
        {
            Guid basketId = new Guid(); // TODO: Initialize to an appropriate value
            Basket target = new Basket(basketId); // TODO: Initialize to an appropriate value
            Guid basketID = new Guid(); // TODO: Initialize to an appropriate value
            target.Delete(basketID);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for GetLines
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PlataformaComercio.Business.dll")]
        public void GetLinesTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Basket_Accessor target = new Basket_Accessor(param0); // TODO: Initialize to an appropriate value
            target.GetLines();
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for InternalContructor
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PlataformaComercio.Business.dll")]
        public void InternalContructorTest()
        {
            PrivateObject param0 = null; // TODO: Initialize to an appropriate value
            Basket_Accessor target = new Basket_Accessor(param0); // TODO: Initialize to an appropriate value
            string name = string.Empty; // TODO: Initialize to an appropriate value
            Nullable<Guid> userID = new Nullable<Guid>(); // TODO: Initialize to an appropriate value
            target.InternalContructor(name, userID);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for MigrateFromAnonymousUser
        ///</summary>
        [TestMethod()]
        public void MigrateFromAnonymousUserTest()
        {
            string basketName = string.Empty; // TODO: Initialize to an appropriate value
            Basket.MigrateFromAnonymousUser(basketName);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for BasketId
        ///</summary>
        [TestMethod()]
        public void BasketIdTest()
        {
            Guid basketId = new Guid(); // TODO: Initialize to an appropriate value
            Basket target = new Basket(basketId); // TODO: Initialize to an appropriate value
            Guid actual;
            actual = target.BasketId;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Lines
        ///</summary>
        [TestMethod()]
        public void LinesTest()
        {
            Guid basketId = new Guid(); // TODO: Initialize to an appropriate value
            Basket target = new Basket(basketId); // TODO: Initialize to an appropriate value
            BasketLineCollection expected = null; // TODO: Initialize to an appropriate value
            BasketLineCollection actual;
            target.Lines = expected;
            actual = target.Lines;
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for PaymentMethod
        ///</summary>
        [TestMethod()]
        public void PaymentMethodTest()
        {
            Guid basketId = new Guid(); // TODO: Initialize to an appropriate value
            Basket target = new Basket(basketId); // TODO: Initialize to an appropriate value
            PaymentMethod actual;
            actual = target.PaymentMethod;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Shipping
        ///</summary>
        [TestMethod()]
        public void ShippingTest()
        {
            Guid basketId = new Guid(); // TODO: Initialize to an appropriate value
            Basket target = new Basket(basketId); // TODO: Initialize to an appropriate value
            BasketShipping actual;
            actual = target.Shipping;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for ShippingCost
        ///</summary>
        [TestMethod()]
        public void ShippingCostTest()
        {
            Guid basketId = new Guid(); // TODO: Initialize to an appropriate value
            Basket target = new Basket(basketId); // TODO: Initialize to an appropriate value
            Decimal actual;
            actual = target.ShippingCost;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for SubTotal
        ///</summary>
        [TestMethod()]
        public void SubTotalTest()
        {
            Guid basketId = new Guid(); // TODO: Initialize to an appropriate value
            Basket target = new Basket(basketId); // TODO: Initialize to an appropriate value
            Decimal actual;
            actual = target.SubTotal;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Total
        ///</summary>
        [TestMethod()]
        public void TotalTest()
        {
            Guid basketId = new Guid(); // TODO: Initialize to an appropriate value
            Basket target = new Basket(basketId); // TODO: Initialize to an appropriate value
            Decimal actual;
            actual = target.Total;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for TotalWeight
        ///</summary>
        [TestMethod()]
        public void TotalWeightTest()
        {
            Guid basketId = new Guid(); // TODO: Initialize to an appropriate value
            Basket target = new Basket(basketId); // TODO: Initialize to an appropriate value
            Decimal actual;
            actual = target.TotalWeight;
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
