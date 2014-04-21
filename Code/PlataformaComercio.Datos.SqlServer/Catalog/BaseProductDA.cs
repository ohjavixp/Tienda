using System;
using System.Data.SqlClient;
using PlataformaComercio.Datos.Fachada.Catalog;
using PlataformaComercio.Entities.Product;
using PlataformaComercio.FrameWork.DataAccess;

namespace PlataformaComercio.Datos.SqlServer.Catalog
{
    public class BaseProductDA : IBaseProduct
    {
        public String Add(EntBaseProduct entBaseProduct)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spBaseProduct_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@BaseProductId", entBaseProduct.BaseProductId);
            comando.Parameters.AddWithValue("@Name", entBaseProduct.Name);
            comando.Parameters.AddWithValue("@IsActive", entBaseProduct.IsActive);
            comando.Parameters.AddWithValue("@LastMod", entBaseProduct.LastMod);
            comando.Parameters.AddWithValue("@TradeId", entBaseProduct.TradeId);
            comando.Parameters.AddWithValue("@PropertyCategoryID", entBaseProduct.PropertyCategoryID);
            comando.Parameters.AddWithValue("@PropertySubCategoryID", entBaseProduct.PropertySubCategoryID);
            DBSqlServer db = new DBSqlServer();
            return (String)db.ExecuteScalar(comando);
        }

        public bool Update(EntBaseProduct entBaseProduct)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spBaseProduct_Update";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@BaseProductId", entBaseProduct.BaseProductId);
            comando.Parameters.AddWithValue("@Name", entBaseProduct.Name);
            comando.Parameters.AddWithValue("@IsActive", entBaseProduct.IsActive);
            comando.Parameters.AddWithValue("@LastMod", entBaseProduct.LastMod);
            comando.Parameters.AddWithValue("@TradeId", entBaseProduct.TradeId);
            comando.Parameters.AddWithValue("@PropertyCategoryID", entBaseProduct.PropertyCategoryID);
            comando.Parameters.AddWithValue("@PropertySubCategoryID", entBaseProduct.PropertySubCategoryID);
            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }

        public EntBaseProduct GetByID(String BaseProductId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spBaseProduct_Select_By_ID";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@BaseProductId", BaseProductId);
            DBSqlServer db = new DBSqlServer();
            EntBaseProduct entBaseProduct = null;
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entBaseProduct = new EntBaseProduct();
                    entBaseProduct.BaseProductId = reader.GetString(0);
                    entBaseProduct.Name = reader.GetString(1);
                    entBaseProduct.IsActive = reader.GetBoolean(2);
                    entBaseProduct.LastMod = reader.GetDateTime(3);
                    entBaseProduct.TradeId = reader.GetInt32(4);
                    entBaseProduct.PropertyCategoryID = reader.GetInt32(5);
                    entBaseProduct.PropertySubCategoryID = reader.GetInt32(6);
                }
            }
            return entBaseProduct;
        }

        public bool Delete(String BaseProductId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spBaseProduct_Delete";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@BaseProductId", BaseProductId);
            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }
    }
}