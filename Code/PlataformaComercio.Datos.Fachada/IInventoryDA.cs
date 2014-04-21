using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities.Inventory;


namespace PlataformaComercio.Datos.Fachada
{
    public interface IInventoryDA
    {
        #region Search
        /// <summary>
        /// Realiza una busqueda básica
        /// </summary>
        /// <param name="inventoryId">Id del inventario</param>
        /// <param name="searchText">palabra de busqueda</param>
        /// <returns>Arreglo de <see cref="EntProduct[]"/> con los productos localizados </returns>
        EntProduct[] SearchBasic(string inventoryId, string searchText);

        /// <summary>
        /// Agrega una busqueda a la tabla de estadisticas de busqueda
        /// </summary>
        /// <param name="searchWord">Palabra de busqueda</param>
        /// <param name="searchDateTime">Hora y fecha de la busqueda</param>
        /// <param name="foundItems">Especifica si la busqueda obtuvo registros</param>
        void SearchStatisticsAdd(string searchWord, DateTime searchDateTime, bool foundItems);
        #endregion


        /// <summary>
        /// Obtiene el id de la ultima categoria proporcionada
        /// </summary>
        /// <param name="inventoryID">Id del inventario</param>
        /// <param name="categories">Nombre de las categorias en modo descendente</param>
        /// <returns>CategoryID</returns>
        /// <remarks>Solo se obtiene si las categorias son hijas de la categoria padre Padre/Hijo/SubHijo/SubSubHijo</remarks>
        int GetCategoryIDByName(string idInventario,params string[] categorias);

        
        
        /// <summary>
        /// Obtiene los identificadores del nombre de las categorias proporcionadas
        /// </summary>
        /// <param name="inventoryID">Id del inventario</param>
        /// <param name="categories">Nombre de las categorias en modo descendente</param>
        /// <returns>Arreglo de int[]</returns>
        /// <remarks>Solo se obtiene si las categorias son hijas de la categoria padre Padre/Hijo/SubHijo/SubSubHijo</remarks>
        int[] GetCategoriesIDByName(string inventoryID, params string[] categories);
        
        
        EntInventoryCategory[] ObtenerCategoriasPorIdPadre(string idInventario,int idPadre);
        EntProduct[] ObtenerProductosPorCategoria(string idInventario,params string[] categorias);        
        EntProduct[] GetProductsByCategory(string idInventario, int categoryID);        
        EntProduct ObtenerProductoPorSku(string idInventario,string sku);
        /// <summary>
        /// Obtiene los productos de una marca
        /// </summary>
        /// <param name="idInventario">Inventario</param>
        /// <param name="tradeId">Identificador de la marca</param>
        /// <returns>Colección de productos encontrados</returns>
        EntProduct[] GetProductsByTrade(string idInventario, int tradeId);

        bool Add(EntInventory inventory);
        EntInventory[] GetAll();


        int AddCategory(EntInventoryCategory entInventoryCategory);
        bool UpdateCategory(EntInventoryCategory entInventoryCategory);
        EntInventoryCategory GetCategory(string inventory, int categoryID);
        bool DeleteCategory(string inventory, int categoryID);
        EntInventoryCategory[] GetAllCategories(string inventoryID);
        bool AddProductToInventory(EntInventoryProduct inventoryProduct);
        bool AddProductToCategory(EntInventoryCategoryProduct inventoryProduct);
        bool DeleteProductFromCategory(string inventoryID, int categoryID, string productID);
        EntInventoryProduct GetInventoryProduct(string inventoryID, string productID);


        
    }
}
