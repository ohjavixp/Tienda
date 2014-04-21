using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Entities.Inventory;
using System.Data.SqlClient;

namespace PlataformaComercio.Datos.SqlServer
{
    internal class Common
    {
        public static EntProduct FillProduct(SqlDataReader reader)
        {
            EntProduct producto = new EntProduct();
            producto.SKU = reader.GetString(0).ToLower();
            producto.Name = reader.GetString(1);
            producto.ShortDescription = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
            producto.LargeDescription = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
            producto.Price = reader.GetDecimal(4);
            producto.TradeID = reader.GetInt32(5);
            producto.TradeName = reader.GetString(6);
            producto.Image128 = reader.GetBoolean(7);
            producto.Image256 = reader.GetBoolean(8);
            producto.Weight = reader.GetDecimal(9);
            producto.IsActive = reader.GetBoolean(10);
            producto.Measure = reader.GetString(11);
            producto.CurrencyID = reader.GetInt32(12);
            producto.CurrencyIsoCode = reader.GetString(13);
            return producto;
        }
    }
}
