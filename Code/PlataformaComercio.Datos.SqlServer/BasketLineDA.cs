using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Datos.Fachada;
using System.Data.SqlClient;
using PlataformaComercio.Entities;
using PlataformaComercio.Entities.Basket;
using PlataformaComercio.FrameWork.DataAccess;

namespace PlataformaComercio.Datos.SqlServer
{
    public class BasketLineDA : IBasketLineDA
    {

        #region IBasketLineDA Members

        public int Add(Guid basketId, string name)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spBasketLine_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@BasketId", basketId);
            comando.Parameters.AddWithValue("@Name", name);

            DBSqlServer db = new DBSqlServer();
            return (int)db.ExecuteScalar(comando);
        }

        public EntBasketLine[] Get(Guid basketID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM BasketLine WHERE BasketId=@BasketId";
            comando.Parameters.AddWithValue("@BasketId", basketID);
            

            DBSqlServer db = new DBSqlServer();
            List<EntBasketLine> lines = new List<EntBasketLine>();
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    EntBasketLine entBasketLine = new EntBasketLine();
                    entBasketLine.BasketID = reader.GetGuid(0);
                    entBasketLine.LineID = reader.GetInt32(1);
                    entBasketLine.Name = reader.GetString(2);
                    lines.Add(entBasketLine);
                }
            }

            return lines.ToArray();
        }

        public int AddProduct(EntBasketDetail entBasketDetail)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spBasketDetail_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@BasketId", entBasketDetail.BasketID);
            comando.Parameters.AddWithValue("@LineId", entBasketDetail.LineID);
            comando.Parameters.AddWithValue("@InventoryId", entBasketDetail.InventoryID);
            comando.Parameters.AddWithValue("@ProductId", entBasketDetail.Sku);
            comando.Parameters.AddWithValue("@ProductCategoryId", DBNull.Value);
            comando.Parameters.AddWithValue("@Quantity", entBasketDetail.Quantity);

            DBSqlServer db = new DBSqlServer();
            return (int)db.ExecuteScalar(comando);
        }

        public EntBasketProduct[] GetProducts(Guid basketID, int lineID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT BasketDetailID,Quantity,ProductID FROM BasketDetail WHERE BasketId=@BasketId and LineID=@LineID";
            comando.Parameters.AddWithValue("@BasketId", basketID);
            comando.Parameters.AddWithValue("@LineID", lineID);
            


            DBSqlServer db = new DBSqlServer();
            List<EntBasketProduct> entBasketProducts = new List<EntBasketProduct>();
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {

                    EntBasketProduct entBasketProduct = new EntBasketProduct();
                    entBasketProduct.BasketDetailID = reader.GetInt32(0);
                    entBasketProduct.Quantity = reader.GetDecimal(1);
                    entBasketProduct.SKU = reader.GetString(2);
                    entBasketProducts.Add(entBasketProduct);

                }
            }

            return entBasketProducts.ToArray();
        }

        public EntBasketProduct GetProductBySku(Guid basketID, int lineID, string sku)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT BasketDetailID,Quantity FROM BasketDetail WHERE BasketId=@BasketId and LineID=@LineID AND ProductId=@Sku";
            comando.Parameters.AddWithValue("@BasketId", basketID);
            comando.Parameters.AddWithValue("@LineID", lineID);
            comando.Parameters.AddWithValue("@Sku", sku);


            DBSqlServer db = new DBSqlServer();
            EntBasketProduct entBasketProduct = null;
            
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if(reader.Read())
                {
                    entBasketProduct = new EntBasketProduct();
                    entBasketProduct.BasketDetailID = reader.GetInt32(0);                    
                    entBasketProduct.Quantity = reader.GetDecimal(1);

                }
            }

            return entBasketProduct;
        }

        public void UpdateQuantity(Guid basketID, int lineID, int basketDetailID, decimal quantity, bool replaceValue)
        {
            SqlCommand comando = new SqlCommand();
            if(replaceValue)
                comando.CommandText = "UPDATE BasketDetail SET Quantity = @Quantity WHERE BasketId=@BasketId AND LineId=@LineID AND BasketDetailId=@BasketDetailId";
            else
                comando.CommandText = "UPDATE BasketDetail SET Quantity = Quantity + @Quantity WHERE BasketId=@BasketId AND LineId=@LineID AND BasketDetailId=@BasketDetailId";
            
            comando.Parameters.AddWithValue("@BasketId", basketID);
            comando.Parameters.AddWithValue("@LineID", lineID);
            comando.Parameters.AddWithValue("@BasketDetailId", basketDetailID);
            comando.Parameters.AddWithValue("@Quantity", quantity);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
        }

        public void RemoveProduct(Guid basketID, int lineID, string sku)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "DELETE   FROM BasketDetail WHERE BasketId=@BasketId and LineID=@LineID AND ProductId=@Sku";
            comando.Parameters.AddWithValue("@BasketId", basketID);
            comando.Parameters.AddWithValue("@LineID", lineID);
            comando.Parameters.AddWithValue("@Sku", sku);


            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            
        }
        #endregion
    }
}
