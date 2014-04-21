using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Entities.Inventory;
using System.Data.SqlClient;
using PlataformaComercio.FrameWork.DataAccess;
using PlataformaComercio.FrameWork.Exceptions;

namespace PlataformaComercio.Datos.SqlServer
{
    public class InventoryDA:IInventoryDA
    {


        #region Search
        public EntProduct[] SearchBasic(string inventoryId, string searchText)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spSearchBasic";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@InventoryID", inventoryId);
            comando.Parameters.AddWithValue("@SearchText", searchText);

            DBSqlServer db = new DBSqlServer();
            List<EntProduct> productos = new List<EntProduct>();

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    EntProduct entProducto = Common.FillProduct(reader);
                    entProducto.Inventory = inventoryId;
                    productos.Add(entProducto);
                }
            }

            return productos.ToArray();
        }

        public void SearchStatisticsAdd(string searchWord, DateTime searchDateTime, bool foundItems)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spSearchStatistics_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@SearchWord", searchWord);
            comando.Parameters.AddWithValue("@SearchDateTime", searchDateTime);
            comando.Parameters.AddWithValue("@FoundItems", foundItems);

            DBSqlServer db = new DBSqlServer();
            List<EntProduct> productos = new List<EntProduct>();

            db.ExecuteNonQuery(comando);
        }
        #endregion

        #region ICatalogo Members


        public EntInventoryCategory[] ObtenerCategoriasPorIdPadre(string idInventario, int idPadre)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM InventoryCategory WHERE InventoryID=@IdInventario And FatherID=@IdPadre";
            comando.Parameters.AddWithValue("@IdInventario", idInventario);
            comando.Parameters.AddWithValue("@IdPadre", idPadre);

            DBSqlServer db = new DBSqlServer();
            List<EntInventoryCategory> categorias = new List<EntInventoryCategory>();
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {   
                while (reader.Read())
                {
                    EntInventoryCategory categoria = FillCategory(idInventario, reader);
                    categorias.Add(categoria);
                }
            }

            return categorias.ToArray();
            

        }

        private  EntInventoryCategory FillCategory(string idInventario, SqlDataReader reader)
        {
            EntInventoryCategory categoria = new EntInventoryCategory();
            categoria.InventoryID = idInventario;
            categoria.CategoryID = reader.GetInt32(1);
            categoria.ParentID = reader.GetInt32(2);
            categoria.Name = reader.GetString(3);
            categoria.Description = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
            categoria.IsActive = reader.GetBoolean(5);
            categoria.Show = reader.GetBoolean(6);
            categoria.Order = reader.GetInt16(7);
            categoria.ShortDescription = reader.IsDBNull(8) ? string.Empty : reader.GetString(8);
            return categoria;
        }

        public bool Add(EntInventory inventory)
        {

            SqlCommand comando = new SqlCommand();
            comando.CommandText = "INSERT INTO Inventory VALUES(@InventoryID,@Description,@IsActive)";
            comando.Parameters.AddWithValue("@InventoryID", inventory.InventoryID);
            comando.Parameters.AddWithValue("@Description", inventory.Description);
            comando.Parameters.AddWithValue("@IsActive", inventory.IsActive);


            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            
            return true;
        }

        public int AddCategory(EntInventoryCategory entInventoryCategory)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spInventoryCategory_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@InventoryID", entInventoryCategory.InventoryID);
            comando.Parameters.AddWithValue("@FatherID", entInventoryCategory.ParentID);
            comando.Parameters.AddWithValue("@Name", entInventoryCategory.Name);
            comando.Parameters.AddWithValue("@Description", entInventoryCategory.Description);
            comando.Parameters.AddWithValue("@IsActive", entInventoryCategory.IsActive);
            comando.Parameters.AddWithValue("@Order", entInventoryCategory.Order);
            comando.Parameters.AddWithValue("@ShortDescription", entInventoryCategory.ShortDescription);
            comando.Parameters.AddWithValue("@Show", entInventoryCategory.Show);

            DBSqlServer db = new DBSqlServer();
            return (int)db.ExecuteScalar(comando);
        }

        public bool UpdateCategory(EntInventoryCategory entInventoryCategory)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spInventoryCategory_Update";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@InventoryID", entInventoryCategory.InventoryID);
            comando.Parameters.AddWithValue("@CategoryID", entInventoryCategory.CategoryID);
            comando.Parameters.AddWithValue("@Name", entInventoryCategory.Name);
            comando.Parameters.AddWithValue("@Description", entInventoryCategory.Description);
            comando.Parameters.AddWithValue("@IsActive", entInventoryCategory.IsActive);
            comando.Parameters.AddWithValue("@Order", entInventoryCategory.Order);
            comando.Parameters.AddWithValue("@ShortDescription", entInventoryCategory.ShortDescription);
            comando.Parameters.AddWithValue("@Show", entInventoryCategory.Show);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }


        public bool AddProductToInventory(EntInventoryProduct inventoryProduct)
        { 
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spInventoryProduct_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@InventoryID", inventoryProduct.InventoryID);            
            comando.Parameters.AddWithValue("@ProductID", inventoryProduct.ProductID.ToUpper());            
            comando.Parameters.AddWithValue("@Quantity", inventoryProduct.Quantity);
            comando.Parameters.AddWithValue("@IsActive", inventoryProduct.IsActive);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;                        
        }



        public EntInventoryProduct GetInventoryProduct(string inventoryID, string productID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM InventoryProduct WHERE InventoryID=@InventoryID AND ProductID=@ProductID";
            comando.Parameters.AddWithValue("@InventoryID", inventoryID);
            comando.Parameters.AddWithValue("@ProductID", productID);

            DBSqlServer db = new DBSqlServer();
            EntInventoryProduct inventoryProduct = null;
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    inventoryProduct = new EntInventoryProduct();
                    inventoryProduct.InventoryID = inventoryID;
                    inventoryProduct.ProductID = productID;                    
                    inventoryProduct.Quantity = reader.GetInt32(2);
                    inventoryProduct.IsActive = reader.GetBoolean(3);
                }
            }

            return inventoryProduct;
        }

        public bool DeleteProductFromCategory(string inventoryID, int categoryID, string productID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "DELETE FROM InventoryProductCategory WHERE InventoryID=@InventoryID AND CategoryID=@CategoryID AND ProductID=@ProductID";            
            comando.Parameters.AddWithValue("@InventoryID", inventoryID);
            comando.Parameters.AddWithValue("@CategoryID", categoryID);            
            comando.Parameters.AddWithValue("@ProductID", productID);
            
            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }
        
        public bool AddProductToCategory(EntInventoryCategoryProduct inventoryProduct)
        { 
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spInventoryCategoryProduct_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@InventoryID", inventoryProduct.InventoryID);
            comando.Parameters.AddWithValue("@CategoryID", inventoryProduct.CategoryID);
            comando.Parameters.AddWithValue("@ProductID", inventoryProduct.ProductID.ToUpper());
            comando.Parameters.AddWithValue("@IsPrimary", inventoryProduct.IsPrimary);            
            comando.Parameters.AddWithValue("@IsActive", inventoryProduct.IsActive);            
            comando.Parameters.AddWithValue("@Order", inventoryProduct.Order);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;            
        }

        public EntInventoryCategory GetCategory(string inventory,int categoryID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM InventoryCategory WHERE InventoryID=@IdInventario And CategoryID=@CategoryID";
            comando.Parameters.AddWithValue("@IdInventario", inventory);
            comando.Parameters.AddWithValue("@CategoryID", categoryID);

            DBSqlServer db = new DBSqlServer();
            EntInventoryCategory categoria = null;

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    categoria = FillCategory(inventory, reader);
                }
            }

            return categoria;
        }

        public bool DeleteCategory(string inventory, int categoryID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "DELETE FROM InventoryCategory WHERE InventoryID=@InventoryID AND CategoryID=@CategoryID";
            comando.Parameters.AddWithValue("@InventoryID", inventory);
            comando.Parameters.AddWithValue("@CategoryID", categoryID);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);

            return true;
        }

        public EntInventoryCategory[] GetAllCategories(string inventoryID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM InventoryCategory WHERE InventoryID=@InventoryID Order By FatherID,CategoryID Asc ";
            comando.Parameters.AddWithValue("@InventoryID", inventoryID);

            DBSqlServer db = new DBSqlServer();
            List<EntInventoryCategory> categories = new List<EntInventoryCategory>();

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    categories.Add(FillCategory(inventoryID, reader));
                }
            }

            return categories.ToArray();
        }

        public EntInventory[] GetAll()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM Inventory";            

            DBSqlServer db = new DBSqlServer();
            List<EntInventory> inventories = new List<EntInventory>();

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    EntInventory inventory = new EntInventory();
                    inventory.InventoryID = reader.GetString(0);
                    inventory.Description = reader.GetString(1);
                    inventory.IsActive = reader.GetBoolean(2);
                    inventories.Add(inventory);
                }
            }

            return inventories.ToArray();
        }


        /// <summary>
        /// Obtiene el id de la ultima categoria proporcionada
        /// </summary>
        /// <param name="inventoryID">Id del inventario</param>
        /// <param name="categories">Nombre de las categorias en modo descendente</param>
        /// <returns>CategoryID</returns>
        /// <remarks>Solo se obtiene si las categorias son hijas de la categoria padre Padre/Hijo/SubHijo/SubSubHijo</remarks>
        public int GetCategoryIDByName(string inventoryID, params string[] categories)
        {
            if (categories.Length == 0)
                return -1;

            int categoryID = 0;
            
            foreach (string categoryName in categories)
            {
                int returnValue = GetCategoryIDByNameAndParentID(inventoryID, categoryID, categoryName);
                categoryID = returnValue;
            }

            return categoryID;            
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

            List<int> categoriesID = new List<int>();
            
            if (categories.Length == 0)
                return categoriesID.ToArray();

            int categoryID = 0;

            foreach (string categoryName in categories)
            {
                int returnValue = GetCategoryIDByNameAndParentID(inventoryID, categoryID, categoryName);
                categoryID = returnValue;
                categoriesID.Add(returnValue);
            }

            return categoriesID.ToArray();            
        }

        private static int GetCategoryIDByNameAndParentID(string inventoryID, int categoryID, string categoryName)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spGetCategoryIDByNameAndParentCategory";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@InventoryID", inventoryID);
            comando.Parameters.AddWithValue("@ParentID", categoryID);
            comando.Parameters.AddWithValue("@Name", categoryName);

            DBSqlServer db = new DBSqlServer();
            int returnValue;

            bool hasValue = Int32.TryParse(db.ExecuteScalar(comando).ToString(), out returnValue);

            if (!hasValue)
                throw new NotFoundException(String.Format("No existe la categoria {0} con el padre {1} en el inventario {2}", categoryName, categoryID, inventoryID));
            return returnValue;
        }
        


        public EntProduct[] ObtenerProductosPorCategoria(string idInventario,params string[] categorias)
        {
            int categoriaId = GetCategoryIDByName(idInventario,categorias);
            return GetProductsByCategory(idInventario,categoriaId);
        }





        public EntProduct[] GetProductsByCategory(string idInventario, int categoryID)
        {            

            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spGetProductsByCategory";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@InventoryID", idInventario);
            comando.Parameters.AddWithValue("@CategoryID", categoryID);

            DBSqlServer db = new DBSqlServer();
            List<EntProduct> productos = new List<EntProduct>();
            
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    EntProduct entProducto = Common.FillProduct(reader); 
                    entProducto.Inventory = idInventario;
                    productos.Add(entProducto);
                }
            }

            return productos.ToArray();
        }

        public EntProduct[] GetProductsByTrade(string idInventario, int tradeId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spGetProductsByTrade";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@InventoryID", idInventario);
            comando.Parameters.AddWithValue("@TradeID", tradeId);

            DBSqlServer db = new DBSqlServer();
            List<EntProduct> productos = new List<EntProduct>();

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    EntProduct entProducto = Common.FillProduct(reader);
                    entProducto.Inventory = idInventario;
                    productos.Add(entProducto);
                }
            }

            return productos.ToArray();
        }

      

        public EntProduct ObtenerProductoPorSku(string idInventario, string sku)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spGetInventoryProductByID";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@InventoryID", idInventario);
            comando.Parameters.AddWithValue("@ProductID", sku);

            DBSqlServer db = new DBSqlServer();
            EntProduct entProducto = null;

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if(reader.Read())
                {
                    entProducto = Common.FillProduct(reader);
                    entProducto.Inventory = idInventario;                    
                }
            }

            return entProducto;
        }

        #endregion

      
      
      
        

        
    }
}
