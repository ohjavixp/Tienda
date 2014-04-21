using PlataformaComercio.Business;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PlataformaComercio.Entities.Inventory;

namespace PlataformaComercio.TestProject
{
    
    
    /// <summary>
    ///This is a test class for InventoryTest and is intended
    ///to contain all InventoryTest Unit Tests
    ///</summary>
    [TestClass()]
    public class InventoryTest
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
        ///A test for Inventory Constructor
        ///</summary>
        [TestMethod()]
        public void InventoryConstructorTest()
        {
            Inventory target = new Inventory();            
            Assert.IsNotNull(target);
        }

        /// <summary>
        ///A test for Add
        ///</summary>
        [TestMethod()]
        public void AddTest()
        {
            Inventory target = new Inventory(); // TODO: Initialize to an appropriate value
            EntInventory entInventory = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.Add(entInventory);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddCategory
        ///</summary>
        [TestMethod()]
        public void AddCategoryTest()
        {
            Inventory target = new Inventory(); // TODO: Initialize to an appropriate value
            EntInventoryCategory entInventoryCategory = null; // TODO: Initialize to an appropriate value
            int expected = 0; // TODO: Initialize to an appropriate value
            int actual;
            actual = target.AddCategory(entInventoryCategory);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddProductToCategory
        ///</summary>
        [TestMethod()]
        public void AddProductToCategoryTest()
        {
            Inventory target = new Inventory(); // TODO: Initialize to an appropriate value
            EntInventoryCategoryProduct inventoryCategoryProduct = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddProductToCategory(inventoryCategoryProduct);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AddProductToInventory
        ///</summary>
        [TestMethod()]
        public void AddProductToInventoryTest()
        {
            Inventory target = new Inventory(); // TODO: Initialize to an appropriate value
            EntInventoryProduct inventoryProduct = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.AddProductToInventory(inventoryProduct);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for AsignarImagenes
        ///</summary>
        [TestMethod()]
        [DeploymentItem("PlataformaComercio.Business.dll")]
        public void AsignarImagenesTest()
        {
            Inventory_Accessor target = new Inventory_Accessor(); // TODO: Initialize to an appropriate value
            EntProduct entProducto = null; // TODO: Initialize to an appropriate value
            EntProduct expected = null; // TODO: Initialize to an appropriate value
            EntProduct actual;
            actual = target.AsignarImagenes(entProducto);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for DeleteCategory
        ///</summary>
        [TestMethod()]
        public void DeleteCategoryTest()
        {
            Inventory target = new Inventory(); // TODO: Initialize to an appropriate value
            int categoryID = 0; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.DeleteCategory(categoryID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

  

        /// <summary>
        ///A test for DeleteProductFromCategory
        ///</summary>
        [TestMethod()]
        public void DeleteProductFromCategoryTest()
        {
            Inventory target = new Inventory(); // TODO: Initialize to an appropriate value
            string inventoryID = string.Empty; // TODO: Initialize to an appropriate value
            int categoryID = 0; // TODO: Initialize to an appropriate value
            string productID = string.Empty; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.DeleteProductFromCategory(inventoryID, categoryID, productID);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        /// <summary>
        ///A test for GetAll
        ///</summary>
        [TestMethod()]
        public void GetAllTest()
        {
            Inventory target = new Inventory(); 
            EntInventory[] expected = null;
            EntInventory[] actual;
            actual = target.GetAll();
            Assert.AreNotEqual(expected, actual);
            
            
            
        }

        /// <summary>
        ///A test for GetAllCategories
        ///</summary>
        [TestMethod()]
        public void GetAllCategoriesTest()
        {
            Inventory target = new Inventory(); 
            EntInventoryCategory[] expected = null; 
            EntInventoryCategory[] actual;
            actual = target.GetAllCategories();
            Assert.AreNotEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetCategoriesByFatherID
        ///</summary>
        [TestMethod()]
        public void GetCategoriesByFatherIDTest()
        {
            Inventory target = new Inventory();
            int fatherID = 0; 
            EntInventoryCategory[] expected = null;
            EntInventoryCategory[] actual;
            actual = target.GetCategoriesByFatherID(fatherID);
            Assert.AreNotEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetCategoriesIDByName
        ///</summary>
        [TestMethod()]
        public void GetCategoriesIDByNameTest()
        {
            Inventory target = new Inventory(); // TODO: Initialize to an appropriate value            
            int[] expected = null; // TODO: Initialize to an appropriate value
            int[] actual;
            actual = target.GetCategoriesIDByName("Perros");
            Assert.AreNotEqual(expected, actual);
            
        }

     

        /// <summary>
        ///A test for GetCategory
        ///</summary>
        [TestMethod()]
        public void GetCategoryTest()
        {
            Inventory target = new Inventory(); 
            string inventory = PlataformaComercio.FrameWork.Configuracion.InventoryConfiguration.DefaultInventory; 
            int categoryID = 1;
            EntInventoryCategory expected = null; 
            EntInventoryCategory actual;
            actual = target.GetCategory(inventory, categoryID);
            Assert.AreNotEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetInventoryProduct
        ///</summary>
        [TestMethod()]
        public void GetInventoryProductTest()
        {
            Inventory target = new Inventory(); 
            string inventoryID = PlataformaComercio.FrameWork.Configuracion.InventoryConfiguration.DefaultInventory;
            string productID = "Kit6"; 
            EntInventoryProduct expected = null;
            EntInventoryProduct actual;
            actual = target.GetInventoryProduct(inventoryID, productID);
            Assert.AreNotEqual(expected, actual);            
        }

        /// <summary>
        ///A test for GetProductByID
        ///</summary>
        [TestMethod()]
        public void GetProductByIDTest()
        {
            Inventory target = new Inventory(); 
            string sku = "Kit6"; 
            EntProduct expected = null;
            EntProduct actual;
            actual = target.GetProductByID(sku);
            Assert.AreNotEqual(expected, actual);
            
        }


        /// <summary>
        ///A test for GetProductsByCategory
        ///</summary>
        [TestMethod()]
        public void GetProductsByCategoryTest()
        {
            Inventory target = new Inventory();
            int categoryID = 222; 
            EntProduct[] expected = null; 
            EntProduct[] actual;
            actual = target.GetProductsByCategory(categoryID);
            Assert.AreNotEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetProductsByCategory
        ///</summary>
        [TestMethod()]
        public void GetProductsByCategoryTest1()
        {
            Inventory target = new Inventory(); // TODO: Initialize to an appropriate value            
            EntProduct[] expected = null; // TODO: Initialize to an appropriate value
            EntProduct[] actual;
            actual = target.GetProductsByCategory("perros","alimento","premium","cachorros");
            Assert.AreNotEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetProductsByTrade
        ///</summary>
        [TestMethod()]
        public void GetProductsByTradeTest()
        {
            Inventory target = new Inventory();
            string tradeName = "diamond";
            EntProduct[] expected = null;
            EntProduct[] actual;
            actual = target.GetProductsByTrade(tradeName);
            Assert.AreNotEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for GetProductsByTrade
        ///</summary>
        [TestMethod()]
        public void GetProductsByTradeTest1()
        {
            Inventory target = new Inventory();
            int tradeId = 2; 
            EntProduct[] expected = null;
            EntProduct[] actual;
            actual = target.GetProductsByTrade(tradeId);
            Assert.AreNotEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for SearchBasic
        ///</summary>
        [TestMethod()]
        public void SearchBasicTest()
        {
            Inventory target = new Inventory();
            string searchText = "royal"; 
            EntProduct[] expected = null; 
            EntProduct[] actual;
            actual = target.SearchBasic(searchText,false);
            Assert.AreNotEqual(expected, actual);
            
        }

        /// <summary>
        ///A test for UpdateCategory
        ///</summary>
        [TestMethod()]
        public void UpdateCategoryTest()
        {
            Inventory target = new Inventory(); // TODO: Initialize to an appropriate value
            EntInventoryCategory entInventoryCategory = null; // TODO: Initialize to an appropriate value
            bool expected = false; // TODO: Initialize to an appropriate value
            bool actual;
            actual = target.UpdateCategory(entInventoryCategory);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }
    }
}
