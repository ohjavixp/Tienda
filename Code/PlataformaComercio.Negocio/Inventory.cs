using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.FrameWork.Configuracion;
using PlataformaComercio.FrameWork.Exceptions;
using PlataformaComercio.Business.Catalogs;
using PlataformaComercio.Entities.Catalog;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace PlataformaComercio.Business
{
    public class Inventory:Base
    {        
        
        IInventoryDA inventoryDA;
        public Inventory():base()
        {
            inventoryDA = dataContainer.Resolve<IInventoryDA>();
        }

        public EntProduct[] SearchBasic(string searchText, bool logStatistics)
        {
            return SearchBasic(InventoryConfiguration.DefaultInventory, searchText, logStatistics);
        }

        public EntProduct[] SearchBasic(string inventoryId, string searchText, bool logStatistics)
        {
            var products = inventoryDA.SearchBasic(inventoryId,searchText);

            foreach (var item in products)
            {
                AsignarImagenes(item);
            }

            if (products.Count() <= 0)
            {
                Catalog catalog = new Catalog();
                catalog.AddSearchNotFound(inventoryId, searchText);
            }

            if (logStatistics)
                inventoryDA.SearchStatisticsAdd(searchText, DateTime.Now, products.Count() > 0);

            return products;
        }


        public EntInventoryCategory[] GetCategoriesByFatherID(int fatherID)
        {
            return inventoryDA.ObtenerCategoriasPorIdPadre(InventoryConfiguration.DefaultInventory, fatherID);
        }
        
        

        

        public EntProduct[] GetProductsByCategory(params string[] categorias)
        {
            var productos = inventoryDA.ObtenerProductosPorCategoria(InventoryConfiguration.DefaultInventory, categorias);

            foreach (var item in productos)
            {
                AsignarImagenes(item);   
            }

            return productos;
        }

        public EntProduct[] GetProductsByCategory(int categoryID)
        {
            var productos = inventoryDA.GetProductsByCategory(InventoryConfiguration.DefaultInventory, categoryID);

            foreach (var item in productos)
            {
                AsignarImagenes(item);
            }

            return productos;
        }

        /// <summary>
        /// Obtiene los productos relacionados a partir del nombre de una marca
        /// </summary>
        /// <param name="tradeName">Nombre de la marca</param>
        /// <returns>Colección con los productos localizados</returns>
        public EntProduct[] GetProductsByTrade(string tradeName)
        {
            Trade trade = new Trade();
            EntTrade entTrade = trade.GetByName(tradeName);
            return GetProductsByTrade(entTrade.TradeID);
        }

        /// <summary>
        /// Obtiene los productos relacionados a partir del id de una marca
        /// </summary>
        /// <param name="tradeId">Id de la marca</param>
        /// <returns>Colección con los productos localizados</returns>
        public EntProduct[] GetProductsByTrade(int tradeId)
        {
            var productos = inventoryDA.GetProductsByTrade(InventoryConfiguration.DefaultInventory, tradeId);

            foreach (var item in productos)
            {
                AsignarImagenes(item);
            }

            return productos;
        }


        /// <summary>
        /// Obtiene un producto a partir de su id (sku) en el inventario predeterminado
        /// </summary>        
        /// <param name="sku">Identificador del producto</param>
        /// <returns><see cref="EntProduct"/></returns>
        /// <exception cref="NotFoundException">En caso de que el producto no se encuentre</exception>
        public EntProduct GetProductByID(string sku)
        {
            return GetProductByID(InventoryConfiguration.DefaultInventory, sku);
        }

        /// <summary>
        /// Obtiene un producto a partir de su id (sku)
        /// </summary>
        /// <param name="idInventario">Inventory</param>
        /// <param name="sku">Identificador del producto</param>
        /// <returns><see cref="EntProduct"/></returns>
        /// <exception cref="NotFoundException">En caso de que el producto no se encuentre</exception>
        public EntProduct GetProductByID(string idInventario, string sku)
        {
            EntProduct entProducto = inventoryDA.ObtenerProductoPorSku(idInventario, sku);
            if (entProducto == null)
                throw new NotFoundException(string.Format( "No se localizo el producto {0} en el inventario {1}", sku, idInventario));

            AsignarImagenes(entProducto);
            return entProducto;
        }

        private EntProduct AsignarImagenes(EntProduct entProducto)
        {
            if (entProducto.Image128)
                entProducto.Image128Url = ConfiguracionCatalogo.UrlImagenes128 + "/" + entProducto.SKU.ToLower() + ConfiguracionCatalogo.ExtensionImagen;
            else
                entProducto.Image128Url = ConfiguracionCatalogo.UrlImagenes128 + "/" + ConfiguracionCatalogo.Imagen128Predeterminada.ToLower();

            if (entProducto.Image256)
                entProducto.Image256Url = ConfiguracionCatalogo.UrlImagenes256 + "/" + entProducto.SKU.ToLower() + ConfiguracionCatalogo.ExtensionImagen;
            else
                entProducto.Image256Url = ConfiguracionCatalogo.UrlImagenes256 + "/" + ConfiguracionCatalogo.Imagen256Predeterminada.ToLower();

            return entProducto;
        }

        
        
        public EntInventory[] GetAll()
        {
            return inventoryDA.GetAll();
        }

        public bool Add(EntInventory entInventory)
        {
            if (string.IsNullOrEmpty(entInventory.InventoryID))
                throw new UserException("Debe proporcionar el indentificador del inventario");

            if (string.IsNullOrEmpty(entInventory.Description))
                throw new UserException("Debe proporcionar la descripción del inventario");

            return inventoryDA.Add(entInventory);
        }


        public EntInventoryProduct GetInventoryProduct(string inventoryID, string productID)
        {
            return inventoryDA.GetInventoryProduct(inventoryID, productID);
        }

        public bool AddProductToInventory(EntInventoryProduct inventoryProduct)
        {
            return inventoryDA.AddProductToInventory(inventoryProduct);
        }


        #region Categories
        public bool DeleteProductFromCategory(string inventoryID,int categoryID, string productID)
        {
            return inventoryDA.DeleteProductFromCategory(inventoryID,categoryID, productID);
        }
        public bool AddProductToCategory(EntInventoryCategoryProduct inventoryCategoryProduct)
        {
            if (string.IsNullOrEmpty(inventoryCategoryProduct.InventoryID))
                throw new UserException("Debe especificar el inventario");

            if (string.IsNullOrEmpty(inventoryCategoryProduct.ProductID))
                throw new UserException("Debe especificar el producto");

            if (GetInventoryProduct(inventoryCategoryProduct.InventoryID, inventoryCategoryProduct.ProductID) == null)
            {
                EntInventoryProduct inventoryProduct = new EntInventoryProduct();
                inventoryProduct.InventoryID = inventoryCategoryProduct.InventoryID;
                inventoryProduct.ProductID = inventoryCategoryProduct.ProductID;
                inventoryProduct.Quantity = 0;
                inventoryProduct.IsActive = true;
                AddProductToInventory(inventoryProduct);
            }


            return inventoryDA.AddProductToCategory(inventoryCategoryProduct);
        }

        /// <summary>
        /// Obtiene los identificadores del nombre de las categorias proporcionadas
        /// </summary>
        /// <param name="inventoryID">Id del inventario</param>
        /// <param name="categories">Nombre de las categorias en modo descendente</param>
        /// <returns>Arreglo de int[]</returns>
        /// <remarks>Solo se obtiene si las categorias son hijas de la categoria padre Padre/Hijo/SubHijo/SubSubHijo</remarks>
        public int[] GetCategoriesIDByName(string inventoryID, params string[] categories)
        {
            return inventoryDA.GetCategoriesIDByName(inventoryID, categories);
        }
        /// <summary>
        /// Obtiene los identificadores del nombre de las categorias proporcionadas a partir del inventario predeterminado
        /// </summary>        
        /// <param name="categories">Nombre de las categorias en modo descendente</param>
        /// <returns>Arreglo de int[]</returns>
        /// <remarks>Solo se obtiene si las categorias son hijas de la categoria padre Padre/Hijo/SubHijo/SubSubHijo</remarks>
        public int[] GetCategoriesIDByName(params string[] categories)
        {
            return inventoryDA.GetCategoriesIDByName(InventoryConfiguration.DefaultInventory, categories);
        }
        public int AddCategory(EntInventoryCategory entInventoryCategory)
        {
            if (string.IsNullOrEmpty(entInventoryCategory.Name))
                throw new UserException("Debe proporcionar nombre de la categoria");

            return inventoryDA.AddCategory(entInventoryCategory);
        }

        public bool UpdateCategory(EntInventoryCategory entInventoryCategory)
        {
            if (string.IsNullOrEmpty(entInventoryCategory.Name))
                throw new UserException("Debe proporcionar nombre de la categoria");
            return inventoryDA.UpdateCategory(entInventoryCategory);
        }

        public EntInventoryCategory GetCategory(string inventory, int categoryID)
        {
            return inventoryDA.GetCategory(inventory, categoryID);
        }


        public bool DeleteCategory(int categoryID)
        {
            return DeleteCategory(InventoryConfiguration.DefaultInventory, categoryID);
        }

        public bool DeleteCategory(string inventory, int categoryID)
        {
            EntInventoryCategory[] categories = GetCategoriesByFatherID(categoryID);

            if (categories.Length > 0)
                throw new UserException("Debe primero eliminar las categorias hijas");

            return inventoryDA.DeleteCategory(inventory, categoryID);
        }

        /// <summary>
        /// Obtiene todas las categorias ordenadas por ParentID y CategoryID en forma Ascendente
        /// </summary>
        /// <returns></returns>
        public EntInventoryCategory[] GetAllCategories()
        {
            return inventoryDA.GetAllCategories(InventoryConfiguration.DefaultInventory);
        }
        #endregion


    }
}
