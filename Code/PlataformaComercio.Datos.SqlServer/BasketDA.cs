using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Datos.Fachada;
using System.Data.SqlClient;
using PlataformaComercio.Entities.Inventory;
using PlataformaComercio.Entities.Basket;
using PlataformaComercio.FrameWork.DataAccess;
using PlataformaComercio.Entities.Shipping;
using System.Data;

namespace PlataformaComercio.Datos.SqlServer
{
    public class BasketDA : IBasketDA
    {

        

        #region IBasketDA Members

        public EntBasket Get(Guid userId, string basketName)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM Basket WHERE Name=@Name AND UserId=@UserID";
            comando.Parameters.AddWithValue("@Name", basketName);
            comando.Parameters.AddWithValue("@UserId", userId);

            DBSqlServer db = new DBSqlServer();
            EntBasket entBasket = null;
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if(reader.Read())
                {
                    entBasket = new EntBasket();
                    entBasket.ID = reader.GetGuid(0);
                    entBasket.Name = reader.GetString(1);
                    entBasket.CreationDate = reader.GetDateTime(2);
                    entBasket.LastUpdateDate = reader.GetDateTime(3);
                    entBasket.UserID = reader.GetGuid(4);
                    entBasket.IsAnonymous = reader.GetBoolean(5);
                }
            }

            return entBasket;
        }

        public Guid Add(EntBasket entBasket)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spBasket_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Name", entBasket.Name);
            comando.Parameters.AddWithValue("@CreationDate", entBasket.CreationDate);
            comando.Parameters.AddWithValue("@LastUpdateDate", entBasket.LastUpdateDate);
            comando.Parameters.AddWithValue("@UserId", entBasket.UserID);
            comando.Parameters.AddWithValue("@IsAnonymous", entBasket.IsAnonymous);

            DBSqlServer db = new DBSqlServer();
            return (Guid)db.ExecuteScalar(comando);
        }

        public bool Delete(Guid basketID)
        {             
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spBasket_Delete";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@BasketId", basketID);
            

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }

        public bool AddShippingAddress(EntShippingAddress shippingAddress)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spBasketShippingAddress_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@BasketId", shippingAddress.BasketID);
            comando.Parameters.AddWithValue("@ShippingId", shippingAddress.ShippingId);
            comando.Parameters.AddWithValue("@CountryId", shippingAddress.CountryID);
            comando.Parameters.AddWithValue("@ZipCode", shippingAddress.ZipCode);
            comando.Parameters.AddWithValue("@NeighborghoodID", shippingAddress.NeighborghoodID);
            comando.Parameters.AddWithValue("@Street", shippingAddress.Street);
            comando.Parameters.AddWithValue("@StreetNumber", shippingAddress.StreetNumber);
            comando.Parameters.AddWithValue("@StreetInternalNumber", shippingAddress.StreetInternalNumber);
            comando.Parameters.AddWithValue("@StreetBetween", shippingAddress.StreetBetween);
            comando.Parameters.AddWithValue("@AddressName", shippingAddress.AddressName);
            comando.Parameters.AddWithValue("@TelephoneContact", shippingAddress.TelephoneContact);
            comando.Parameters.AddWithValue("@Comments", shippingAddress.Comments);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }

        public EntShippingAddress GetShippingAddress(Guid basketID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM BasketShippingAddress WHERE BasketId=@BasketId";
            comando.Parameters.AddWithValue("@BasketId", basketID);
            

            DBSqlServer db = new DBSqlServer();
            EntShippingAddress entShippingAddress = null;

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entShippingAddress = new EntShippingAddress();
                    entShippingAddress.BasketID = reader.GetGuid(0);
                    entShippingAddress.ShippingId = reader.GetInt32(1);
                    entShippingAddress.CountryID = reader.GetInt32(2);
                    entShippingAddress.ZipCode = reader.GetString(3);
                    entShippingAddress.NeighborghoodID = reader.GetInt32(4);
                    entShippingAddress.Street = reader.GetString(5);
                    entShippingAddress.StreetNumber = reader.GetString(6);
                    entShippingAddress.StreetInternalNumber = reader.GetString(7);
                    entShippingAddress.StreetBetween = reader.GetString(8);
                    entShippingAddress.AddressName = reader.GetString(9);
                    entShippingAddress.TelephoneContact = reader.GetString(10);
                    entShippingAddress.Comments = reader.GetString(11);
                }
            }

            return entShippingAddress;
        }

        public bool UpdateShippingAddress(EntShippingAddress shippingAddress)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spBasketShippingAddress_Update";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@BasketId", shippingAddress.BasketID);            
            comando.Parameters.AddWithValue("@CountryId", shippingAddress.CountryID);
            comando.Parameters.AddWithValue("@ZipCode", shippingAddress.ZipCode);
            comando.Parameters.AddWithValue("@NeighborghoodID", shippingAddress.NeighborghoodID);
            comando.Parameters.AddWithValue("@Street", shippingAddress.Street);
            comando.Parameters.AddWithValue("@StreetNumber", shippingAddress.StreetNumber);
            comando.Parameters.AddWithValue("@StreetInternalNumber", shippingAddress.StreetInternalNumber);
            comando.Parameters.AddWithValue("@StreetBetween", shippingAddress.StreetBetween);
            comando.Parameters.AddWithValue("@AddressName", shippingAddress.AddressName);
            comando.Parameters.AddWithValue("@TelephoneContact", shippingAddress.TelephoneContact);
            comando.Parameters.AddWithValue("@Comments", shippingAddress.Comments);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }

        public EntBasketPayment GetBasketPayment(Guid basketId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM BasketPayment WHERE BasketId=@BasketId";
            comando.Parameters.AddWithValue("@BasketId", basketId);
            

            DBSqlServer db = new DBSqlServer();
            EntBasketPayment entBasketPayment = null;
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entBasketPayment = new EntBasketPayment();
                    entBasketPayment.PaymentId = reader.GetInt32(1);
                    entBasketPayment.TotalPayed = reader.GetDecimal(2);
                    entBasketPayment.Status = reader.GetInt16(3);
                }
            }

            return entBasketPayment;
        }
        
        public bool AddPaymentMethod(EntBasketPayment paymentMethod, Guid basketId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spBasketPayment_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@BasketId", basketId);            
            comando.Parameters.AddWithValue("@PaymentID",paymentMethod.PaymentId);
            comando.Parameters.AddWithValue("@TotalPayed",paymentMethod.TotalPayed);
            comando.Parameters.AddWithValue("@Status", paymentMethod.Status);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }

        public bool DeleteAllPaymentMethods( Guid basketId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "DELETE FROM BasketPayment WHERE BasketId = @BasketId";
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@BasketId", basketId);            

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }


        #region Shipping

        

        public void AddShippingMethod(Guid basketId,int shippingId, int shippingCostId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "INSERT INTO BasketShippingMethod VALUES (@BasketId,@ShippingId,@ShippingCostId)";
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@BasketId", basketId);
            comando.Parameters.AddWithValue("@ShippingId", shippingId);
            comando.Parameters.AddWithValue("@ShippingCostId", shippingCostId);            

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);            
        }

        public void UpdateShippingMethod(Guid basketId, int shippingId, int shippingCostId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "UPDATE BasketShippingMethod SET ShippingCostId=@ShippingCostId WHERE BasketId=@BasketId AND ShippingId = @ShippingId";
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@BasketId", basketId);
            comando.Parameters.AddWithValue("@ShippingId", shippingId);
            comando.Parameters.AddWithValue("@ShippingCostId", shippingCostId);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
        }

        public int GetShippingMethod(Guid basketId, int shippingId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT ShippingCostId FROM BasketShippingMethod  WHERE BasketId=@BasketId AND ShippingId = @ShippingId";
            comando.CommandType = System.Data.CommandType.Text;
            comando.Parameters.AddWithValue("@BasketId", basketId);
            comando.Parameters.AddWithValue("@ShippingId", shippingId);

            DBSqlServer db = new DBSqlServer();

            object result = db.ExecuteScalar(comando);
            if (result != null)
                return (int)result;
            else
                return -1;           

            
        }



        #endregion

        #endregion
    }
}
