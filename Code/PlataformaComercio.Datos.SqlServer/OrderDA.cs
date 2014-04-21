namespace PlataformaComercio.Datos.SqlServer
{
    using PlataformaComercio.Datos.Fachada;
    using PlataformaComercio.Entities;
    using PlataformaComercio.Entities.Order;
    using PlataformaComercio.FrameWork.DataAccess;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class OrderDA : IOrderDA
    {
        #region IOrderDA Members

        public int ConvertFromBasket(Guid basketId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spOrder_ConvertFromBasket";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@BasketId", basketId);

            DBSqlServer db = new DBSqlServer();
            return (int)db.ExecuteScalar(comando);
        }

        public EntOrderShippingAddress GetShippingAddress(int orderId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spOrder_GetShippingAddress";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@OrderId", orderId);


            DBSqlServer db = new DBSqlServer();
            EntOrderShippingAddress entShippingAddress = null;

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entShippingAddress = new EntOrderShippingAddress();
                    entShippingAddress.OrderId = reader.GetInt32(0);
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

        public decimal GetShippingCost(int orderId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spOrder_GetShippingCost";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@OrderId", orderId);

            DBSqlServer db = new DBSqlServer();

            var resultDB = db.ExecuteScalar(comando);
            return resultDB == null ? 0 : (decimal)resultDB;
        }

        public EntOrderPayment[] GetOrderPayment(int orderId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spOrder_GetPayment";
            comando.Parameters.AddWithValue("@OrderId", orderId);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            DBSqlServer db = new DBSqlServer();
            List<EntOrderPayment> result = new List<EntOrderPayment>();
            using (var reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    result.Add(new EntOrderPayment()
                    {
                        OrderId = reader.GetInt32(0),
                        PaymentId = reader.GetInt32(1),
                        TotalPayed = reader.GetDecimal(2),
                        Status = reader.GetInt16(3)
                    });
                }
            }

            return result.ToArray();
        }

        public int GetShippingMethod(int orderId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spOrder_GetShippingId";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@OrderId", orderId);

            DBSqlServer db = new DBSqlServer();

            var resultDB = db.ExecuteScalar(comando);
            return resultDB == null ? 0 : (int)resultDB;
        }

        /// <summary>
        /// Obtiene los productos de una orden
        /// </summary>
        /// <param name="orderId">Id de la orden</param>
        /// <returns>Productos</returns>
        public EntOrderProduct[] GetProducts(int orderId)
        {
            SqlCommand comando = new SqlCommand()
            {
                CommandText = "spOrder_GetProducts",
                CommandType = System.Data.CommandType.StoredProcedure
            };

            comando.Parameters.AddWithValue("@OrderId", orderId);

            List<EntOrderProduct> result = new List<EntOrderProduct>();
            DBSqlServer db = new DBSqlServer();

            using (var reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    result.Add(FillEntOrderProduct(reader));
                }
            }

            return result.ToArray();
        }

        private EntOrderProduct FillEntOrderProduct(SqlDataReader reader)
        {
            EntOrderProduct entOrderProduct = new EntOrderProduct()
            {
                OrderId = reader.GetInt32(0),
                LineId = reader.GetInt32(1),
                OrderLineDetailID = reader.GetInt32(2),
                InventoryId = reader.GetString(3),
                Sku = reader.GetString(4),
                ProductCategoryId = reader.GetInt32(5),
                Quantity = reader.GetInt32(6),
                UnitPrice = reader.GetDecimal(7)
            };

            return entOrderProduct;
        }

        /// <summary>
        /// Obtiene una orden a partir de su id
        /// </summary>
        /// <param name="orderId">Id de la orden</param>
        /// <returns>Orden</returns>
        public EntOrders GetById(int orderId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spOrder_GetById";
            comando.Parameters.AddWithValue("@OrderId",orderId);
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            DBSqlServer db = new DBSqlServer();

            using (var reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    return FillOrder(reader);
                }
                else
                {
                    return null;
                }
            }
        }

        /// <summary>
        /// Obtiene todas las ordenes
        /// </summary>
        /// <returns>Arreglo con las ordenes obtenidas</returns>
        public List<EntOrders> GetAll()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spOrder_GetAll";
            comando.CommandType = System.Data.CommandType.StoredProcedure;

            DBSqlServer db = new DBSqlServer();
            List<EntOrders> orders = new List<EntOrders>();
            using (var reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    orders.Add(FillOrder(reader));
                }
            }

            return orders;
        }

        private EntOrders FillOrder(SqlDataReader reader)
        {
            EntOrders entOrder = new EntOrders()
            {
                OrderId = reader.GetInt32(0),
                CreationDate = reader.GetDateTime(1),
                LastUpdate = reader.GetDateTime(2),
                UserID = reader.GetGuid(3),
                Status = reader.GetInt16(4),
                SubTotal = reader.GetDecimal(5),
                ClientName = reader.GetString(6)
            };

            return entOrder;
        }

        #endregion
    }
}
