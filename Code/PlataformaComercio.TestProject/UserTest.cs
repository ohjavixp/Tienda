using PlataformaComercio.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PlataformaComercio.Entities.User;

namespace PlataformaComercio.TestProject
{
    
    
    /// <summary>
    ///This is a test class for UserTest and is intended
    ///to contain all UserTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserTest
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
        ///A test for User Constructor
        ///</summary>
        [TestMethod()]
        public void UserConstructorTest()
        {
            User target = new User();
            Assert.Inconclusive("TODO: Implement code to verify target");
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            User target = new User(); // TODO: Initialize to an appropriate value
            EntUser entUser = null; // TODO: Initialize to an appropriate value
            Guid expected = new Guid(); // TODO: Initialize to an appropriate value
            Guid actual;
            actual = target.Add(entUser);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddAddress
        ///</summary>
        [TestMethod()]
        public void AddAddressTest()
        {
            User target = new User(); // TODO: Initialize to an appropriate value
            EntUserAddress entUserAddress = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.AddAddress(entUserAddress);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAddressByID
        ///</summary>
        [TestMethod()]
        public void GetAddressByIDTest()
        {
            User target = new User(); // TODO: Initialize to an appropriate value
            Guid userID = new Guid(); // TODO: Initialize to an appropriate value
            int addressID = 0; // TODO: Initialize to an appropriate value
            EntUserAddress expected = null; // TODO: Initialize to an appropriate value
            EntUserAddress actual;
            actual = target.GetAddressByID(userID, addressID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetByEmail
        ///</summary>
        [TestMethod()]
        public void GetByEmailTest()
        {
            User target = new User(); // TODO: Initialize to an appropriate value
            string email = string.Empty; // TODO: Initialize to an appropriate value
            EntUser expected = null; // TODO: Initialize to an appropriate value
            EntUser actual;
            actual = target.GetByEmail(email);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetByID
        ///</summary>
        [TestMethod()]
        public void GetByIDTest()
        {
            User target = new User(); // TODO: Initialize to an appropriate value
            Guid userID = new Guid(); // TODO: Initialize to an appropriate value
            EntUser expected = null; // TODO: Initialize to an appropriate value
            EntUser actual;
            actual = target.GetByID(userID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetByUserName
        ///</summary>
        [TestMethod()]
        public void GetByUserNameTest()
        {
            User target = new User(); // TODO: Initialize to an appropriate value
            string userName = string.Empty; // TODO: Initialize to an appropriate value
            EntUser expected = null; // TODO: Initialize to an appropriate value
            EntUser actual;
            actual = target.GetByUserName(userName);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for UpdateAddress
        ///</summary>
        [TestMethod()]
        public void UpdateAddressTest()
        {
            User target = new User(); // TODO: Initialize to an appropriate value
            EntUserAddress entUserAddress = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.UpdateAddress(entUserAddress);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PlataformaComercio.Business.dll")]
        public void ValidateTest()
        {
            User_Accessor target = new User_Accessor(); // TODO: Initialize to an appropriate value
            EntUser entUser = null; // TODO: Initialize to an appropriate value
            target.Validate(entUser);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }

        /// <summary>
        ///A test for ValidateUserAddress
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PlataformaComercio.Business.dll")]
        public void ValidateUserAddressTest()
        {
            User_Accessor target = new User_Accessor(); // TODO: Initialize to an appropriate value
            EntUserAddress entUserAddress = null; // TODO: Initialize to an appropriate value
            target.ValidateUserAddress(entUserAddress);
            Assert.Inconclusive("A method that does not return a value cannot be verified.");
        }
    }
}
