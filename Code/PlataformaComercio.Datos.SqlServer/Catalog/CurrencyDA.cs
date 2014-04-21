using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Datos.Fachada.Catalog;
using System.Data.SqlClient;
using PlataformaComercio.Entities.Catalog;
using PlataformaComercio.FrameWork.DataAccess;

namespace PlataformaComercio.Datos.SqlServer.Catalog
{
    public class CurrencyDA : ICurrencyDA
    {
        public Int32 Add(EntCurrency entCurrency)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spCurrency_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CurrencyId", entCurrency.CurrencyId);
            comando.Parameters.AddWithValue("@Name", entCurrency.Name);
            comando.Parameters.AddWithValue("@Sign", entCurrency.Sign);
            comando.Parameters.AddWithValue("@IsoCode", entCurrency.IsoCode);
            DBSqlServer db = new DBSqlServer();
            return (Int32)db.ExecuteScalar(comando);
        }

        public bool Update(EntCurrency entCurrency)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spCurrency_Update";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CurrencyId", entCurrency.CurrencyId);
            comando.Parameters.AddWithValue("@Name", entCurrency.Name);
            comando.Parameters.AddWithValue("@Sign", entCurrency.Sign);
            comando.Parameters.AddWithValue("@IsoCode", entCurrency.IsoCode);
            comando.Parameters.AddWithValue("@ExchangeRate", entCurrency.ExchangeRate);
            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }

        public EntCurrency GetByID(Int32 CurrencyId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spCurrency_Select_By_ID";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CurrencyId", CurrencyId);
            DBSqlServer db = new DBSqlServer();
            EntCurrency entCurrency = null;
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entCurrency = Fill(reader);
                }
            }
            return entCurrency;
        }

        private EntCurrency Fill(SqlDataReader reader)
        {
            EntCurrency entCurrency = new EntCurrency() 
            { CurrencyId = reader.GetInt32(0), Name = reader.GetString(1), Sign = reader.GetString(2), IsoCode = reader.GetString(3), ExchangeRate = reader.GetDecimal(4) };
            return entCurrency;
        }

        public bool Delete(Int32 CurrencyId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spCurrency_Delete";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@CurrencyId", CurrencyId);
            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }


        public EntCurrency[] GetAll()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spCurrency_Select_All";
            comando.CommandType = System.Data.CommandType.StoredProcedure;            
            DBSqlServer db = new DBSqlServer();
            List<EntCurrency> entCurrency = new List<EntCurrency>();
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    entCurrency.Add( Fill(reader));
                }
            }
            return entCurrency.ToArray();
        }
    }
}
