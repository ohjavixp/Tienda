using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using PlataformaComercio.Data;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Datos.Fachada.Catalog;
using PlataformaComercio.Datos.SqlServer.Catalog;
using PlataformaComercio.Entities.Catalog;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.Entities.Payment;
using PlataformaComercio.Entities.Shipping;
using PlataformaComercio.Entities.UI;
using PlataformaComercio.Entities.User;
using PlataformaComercio.FrameWork.DataAccess;

namespace PlataformaComercio.Datos.SqlServer
{
    public class CatalogDA : ICatalogDA
    {
        #region ICatalogDA Members

        public Entities.User.EntNeighborghood GetNeighborghoodByZipCodeAndId(int neighborghoodId, string zipCode)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * from Colonia WHERE IdColonia=@IdColonia AND CodigoPostal=@ZipCode";
            comando.Parameters.AddWithValue("@IdColonia", neighborghoodId);
            comando.Parameters.AddWithValue("@ZipCode", zipCode);

            DBSqlServer db = new DBSqlServer();
            EntNeighborghood entNeighborghood = null;
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entNeighborghood = FillNeighborghood(reader);
                }
            }

            return entNeighborghood;
        }

        public Entities.User.EntNeighborghood[] GetNeighborghoodByZipCode(string zipCode)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * from Colonia WHERE CodigoPostal=@ZipCode";
            comando.Parameters.AddWithValue("@ZipCode", zipCode);

            DBSqlServer db = new DBSqlServer();
            List<EntNeighborghood> entNeighborghoods = new List<EntNeighborghood>();
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    EntNeighborghood entNeighborghood = FillNeighborghood(reader);
                    entNeighborghoods.Add(entNeighborghood);
                }
            }

            return entNeighborghoods.ToArray();
        }

        private EntNeighborghood FillNeighborghood(SqlDataReader reader)
        {
            EntNeighborghood entNeighborghood = new EntNeighborghood();
            entNeighborghood.CountryID = reader.GetInt32(0);
            entNeighborghood.EstateID = reader.GetInt32(1);
            entNeighborghood.CountyID = reader.GetInt32(2);
            entNeighborghood.ID = reader.GetInt32(3);
            entNeighborghood.Name = reader.GetString(4);
            entNeighborghood.ZipCode = reader.GetString(5);
            return entNeighborghood;
        }

        public EntCounty GetCounty(int countryID, int estateID, int countyID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM Municipio WHERE IdPais=@CountryID AND IdEstado=@EstateID AND IdMunicipio=@CountyID";
            comando.Parameters.AddWithValue("@CountryID", countryID);
            comando.Parameters.AddWithValue("@EstateID", estateID);
            comando.Parameters.AddWithValue("@CountyID", countyID);

            DBSqlServer db = new DBSqlServer();
            EntCounty entCounty = null;
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entCounty = new EntCounty();
                    entCounty.CountryID = reader.GetInt32(0);
                    entCounty.EstateID = reader.GetInt32(1);
                    entCounty.ID = reader.GetInt32(2);
                    entCounty.Name = reader.GetString(3);
                }
            }

            return entCounty;
        }

        public Entities.User.EntState GetState(int countryID, int estateID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM Estado WHERE IdPais=@CountryID AND IdEstado=@EstateID";
            comando.Parameters.AddWithValue("@CountryID", countryID);
            comando.Parameters.AddWithValue("@EstateID", estateID);

            DBSqlServer db = new DBSqlServer();
            EntState entState = null;
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entState = new EntState();
                    entState.CountryID = reader.GetInt32(0);
                    entState.ID = reader.GetInt32(1);
                    entState.Name = reader.GetString(2);
                }
            }

            return entState;
        }

        public Entities.User.EntCountry GetCountry(int countryID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM Pais WHERE IdPais=@CountryID";
            comando.Parameters.AddWithValue("@CountryID", countryID);

            DBSqlServer db = new DBSqlServer();
            EntCountry entCountry = null;
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entCountry = new EntCountry();
                    entCountry.ID = reader.GetInt32(0);
                    entCountry.Name = reader.GetString(1);
                }
            }

            return entCountry;
        }

        #endregion ICatalogDA Members

        #region Trades

        private EntTrade FillTrade(SqlDataReader reader)
        {
            EntTrade trade = new EntTrade();
            trade.TradeID = reader.GetInt32(0);
            trade.Name = reader.GetString(1);
            trade.ShortDescription = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            trade.Description = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            trade.IsActive = reader.GetBoolean(4);
            trade.HasSubSite = reader.GetBoolean(5);
            return trade;
        }

        public EntTrade[] GetAllTrades()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM Trade";

            DBSqlServer db = new DBSqlServer();
            List<EntTrade> trades = new List<EntTrade>();
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    trades.Add(FillTrade(reader));
                }
            }

            return trades.ToArray();
        }

        public EntTrade GetTradeByID(int tradeID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM Trade WHERE TradeID=@TradeID";
            comando.Parameters.AddWithValue("@TradeID", tradeID);

            DBSqlServer db = new DBSqlServer();
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    return FillTrade(reader);
                }
            }

            return null;
        }

        public EntTrade GetTradeByName(string tradeName)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM Trade WHERE Name=@TradeName";
            comando.Parameters.AddWithValue("@TradeName", tradeName);

            DBSqlServer db = new DBSqlServer();
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    return FillTrade(reader);
                }
            }

            return null;
        }

        public int AddTrade(EntTrade trade)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spTrade_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Name", trade.Name);
            comando.Parameters.AddWithValue("@ShortDescription", trade.ShortDescription);
            comando.Parameters.AddWithValue("@Description", trade.Description);
            comando.Parameters.AddWithValue("@IsActive", trade.IsActive);
            comando.Parameters.AddWithValue("@HasSubSite", trade.HasSubSite);

            DBSqlServer db = new DBSqlServer();
            return (int)db.ExecuteScalar(comando);
        }

        public bool UpdateTrade(EntTrade trade)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spTrade_Update";
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@TradeID", trade.TradeID);
            comando.Parameters.AddWithValue("@Name", trade.Name);
            comando.Parameters.AddWithValue("@ShortDescription", trade.ShortDescription);
            comando.Parameters.AddWithValue("@Description", trade.Description);
            comando.Parameters.AddWithValue("@IsActive", trade.IsActive);
            comando.Parameters.AddWithValue("@HasSubSite", trade.HasSubSite);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }

        public bool DeleteTrade(int tradeID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "DELETE FROM Trade WHERE TradeID=@TradeID";
            comando.CommandType = System.Data.CommandType.Text;

            comando.Parameters.AddWithValue("@TradeID", tradeID);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }

        #endregion Trades

        #region Products

        public EntProduct[] GetAllProducts()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spGetAllProducts";
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            DBSqlServer db = new DBSqlServer();
            List<EntProduct> productos = new List<EntProduct>();

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    EntProduct entProducto = Common.FillProduct(reader);
                    productos.Add(entProducto);
                }
            }

            return productos.ToArray();
        }

        public EntProduct GetProductByID(string productID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spGetProductByID";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ProductID", productID);

            DBSqlServer db = new DBSqlServer();
            EntProduct entProducto = null;

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entProducto = Common.FillProduct(reader);
                }
            }

            return entProducto;
        }

        public bool AddProduct(EntProduct product)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spProduct_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ProductID", product.SKU);
            comando.Parameters.AddWithValue("@Name", product.Name);
            comando.Parameters.AddWithValue("@ShortDescription", product.ShortDescription);
            comando.Parameters.AddWithValue("@LargeDescription", product.LargeDescription);
            comando.Parameters.AddWithValue("@LargeDescriptionRaw", product.LargeDescriptionRaw);
            comando.Parameters.AddWithValue("@Price", product.Price);
            comando.Parameters.AddWithValue("@TradeID", product.TradeID);
            comando.Parameters.AddWithValue("@Image128", product.Image128);
            comando.Parameters.AddWithValue("@Image256", product.Image256);
            comando.Parameters.AddWithValue("@IsActive", product.IsActive);
            comando.Parameters.AddWithValue("@Weight", product.Weight);
            comando.Parameters.AddWithValue("@Measure", product.Measure);
            comando.Parameters.AddWithValue("@CurrencyId", product.CurrencyID);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);

            return true;
        }

        public bool UpdateProduct(EntProduct product)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spProduct_Update";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ProductID", product.SKU);
            comando.Parameters.AddWithValue("@Name", product.Name);
            comando.Parameters.AddWithValue("@ShortDescription", product.ShortDescription);
            comando.Parameters.AddWithValue("@LargeDescription", product.LargeDescription);
            comando.Parameters.AddWithValue("@LargeDescriptionRaw", product.LargeDescriptionRaw);
            comando.Parameters.AddWithValue("@Price", product.Price);
            comando.Parameters.AddWithValue("@TradeID", product.TradeID);
            comando.Parameters.AddWithValue("@Image128", product.Image128);
            comando.Parameters.AddWithValue("@Image256", product.Image256);
            comando.Parameters.AddWithValue("@IsActive", product.IsActive);
            comando.Parameters.AddWithValue("@Weight", product.Weight);
            comando.Parameters.AddWithValue("@Measure", product.Measure);
            comando.Parameters.AddWithValue("@CurrencyId", product.CurrencyID);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);

            return true;
        }

        public bool DeleteProduct(string productID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "DELETE FROM Product Where ProductID=@ProductID";
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@ProductID", productID);
            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);

            return true;
        }

        #endregion Products

        #region Shipping

        public decimal GetShippingCost(int shippingCostId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT Cost FROM ShippingCost WHERE shippingCostId=@shippingCostId ";
            comando.Parameters.AddWithValue("@shippingCostId", shippingCostId);

            DBSqlServer db = new DBSqlServer();

            object result = db.ExecuteScalar(comando);
            if (result == null)
                return 0;
            else
                return (decimal)result;
        }

        public EntShippingMethod[] GetShippingMethods(string shippingCostKey)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spGetShippingCostByCostKey";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@ShippingCostKey", shippingCostKey);

            DBSqlServer db = new DBSqlServer();
            List<EntShippingMethod> shippingMethods = new List<EntShippingMethod>();

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    EntShippingMethod shippingMethod = FillShippingMethod(reader);
                    shippingMethods.Add(shippingMethod);
                }
            }

            return shippingMethods.ToArray();
        }

        public EntShippingMethod GetShippingMethod(int shippingMethodId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM vShippingCost WHERE ShippingCostId=@ShippingCostId";
            comando.Parameters.AddWithValue("@ShippingCostId", shippingMethodId);

            DBSqlServer db = new DBSqlServer();

            EntShippingMethod shippingMethod = null;
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    shippingMethod = FillShippingMethod(reader);
                }
            }

            return shippingMethod;
        }

        private static EntShippingMethod FillShippingMethod(SqlDataReader reader)
        {
            EntShippingMethod shippingMethod = new EntShippingMethod();
            shippingMethod.ShippingCostId = reader.GetInt32(0);
            shippingMethod.Cost = reader.GetDecimal(2);
            shippingMethod.MaxWeight = reader.GetDecimal(3);
            shippingMethod.AditionalCost = reader.GetDecimal(4);
            shippingMethod.IsActive = reader.GetBoolean(5);

            shippingMethod.Company = new EntShippingCompany();
            shippingMethod.Company.ShippingCompanyId = reader.GetInt32(6);
            shippingMethod.Company.Name = reader.GetString(7);
            shippingMethod.Company.IsActive = reader.GetBoolean(8);

            shippingMethod.ShippingType = new EntShippingType();
            shippingMethod.ShippingType.ShippingTypeId = reader.GetInt32(9);
            shippingMethod.ShippingType.Name = reader.GetString(10);
            return shippingMethod;
        }

        #endregion Shipping

        #region Payment

        public EntPayment GetPayment(int paymentId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM Payment WHERE PaymentId=@PaymentId";
            comando.Parameters.AddWithValue("@PaymentId", paymentId);

            DBSqlServer db = new DBSqlServer();
            EntPayment entPayment = null;

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entPayment = new EntPayment();
                    entPayment.PaymentId = reader.GetInt32(0);
                    entPayment.Name = reader.GetString(1);
                    entPayment.IsActive = reader.GetBoolean(2);
                }
            }

            return entPayment;
        }

        #endregion Payment

        #region Search

        public void AddSearchNotFound(string inventoryId, string searchString)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spSearchNotFound_Add";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@InventoryId", inventoryId);
            comando.Parameters.AddWithValue("@SearchString", searchString);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
        }

        #endregion Search

        #region SiteMap

        /// <summary>
        /// Obtiene una lista de la información existente para la generación del sitemap
        /// </summary>
        public EntSiteMapUI[] GetShowSiteMap()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spSiteMap_GetForGenerateSiteMap";
            comando.CommandType = CommandType.StoredProcedure;

            DBSqlServer db = new DBSqlServer();
            List<EntSiteMapUI> result = new List<EntSiteMapUI>();

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    EntSiteMapUI entity = new EntSiteMapUI();
                    entity.Url = reader.GetString(0);
                    entity.LasMod = reader.GetDateTime(1);
                    entity.Source = reader.GetInt32(2);
                    result.Add(entity);
                }
            }

            return result.ToArray();
        }

        #endregion SiteMap

        public Fachada.Catalog.IBaseProduct baseProduct;

        public Fachada.Catalog.IBaseProduct BaseProduct
        {
            get
            {
                if (baseProduct == null)
                    baseProduct = new BaseProductDA();
                return baseProduct;
            }
        }

        public IPropertyCategory propertyCategory;

        public IPropertyCategory PropertyCategory
        {
            get
            {
                if (propertyCategory == null)
                    propertyCategory = new PropertyCategoryDA();
                return propertyCategory;
            }
        }

        public IPropertySubCategory propertySubCategory;

        public IPropertySubCategory PropertySubCategory
        {
            get
            {
                if (propertySubCategory == null)
                    propertySubCategory = new PropertySubCategoryDA();
                return propertySubCategory;
            }
        }

        public IProperty property;

        public IProperty Property
        {
            get
            {
                if (property == null)
                    property = new PropertyDA();
                return property;
            }
        }
    }
}