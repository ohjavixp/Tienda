﻿using PlataformaComercio.Business.OrderManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace PlataformaComercio.TestProject
{
    
    
    /// <summary>
    ///This is a test class for OrderTest and is intended
    ///to contain all OrderTest Unit Tests
    ///</summary>
    [TestClass()]
    public class OrderTest
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
        ///A test for Order Constructor
        ///</summary>
        [TestMethod()]
        public void OrderConstructorTest()
        {
            Order target = new Order();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for CreateFromBasket
        ///</summary>
        [TestMethod()]
        public void CreateFromBasketTest()
        {
            Order target = new Order(); // TODO: Initialize to an appropriate value
            bool deleteBasket = false; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.CreateFromBasket(deleteBasket);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for CreateFromBasket
        ///</summary>
        [TestMethod()]
        public void CreateFromBasketTest1()
        {
            Order target = new Order(); // TODO: Initialize to an appropriate value
            Guid basketId = new Guid(); // TODO: Initialize to an appropriate value
            bool deleteBasket = false; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.CreateFromBasket(basketId, deleteBasket);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
