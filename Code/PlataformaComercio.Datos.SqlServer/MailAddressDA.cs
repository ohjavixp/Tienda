using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Datos.Fachada;
using PlataformaComercio.Entities;
using System.Data.SqlClient;
using PlataformaComercio.FrameWork.DataAccess;
using PlataformaComercio.Entities.Basket;

namespace PlataformaComercio.Datos.SqlServer
{
    class MailAddressDA : IMailAddressDA
    {
        #region IBasketDA Members

        public EntMailAddress GetMailAddressByID(int id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spGetMailAddressByID";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", id);

            DBSqlServer db = new DBSqlServer();
            EntMailAddress entMailAddress = null;
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entMailAddress = new EntMailAddress();
                    entMailAddress.id = reader.GetInt32(0);
                    entMailAddress.mail = reader.GetString(1);
                    entMailAddress.host = reader.GetString(2);
                    entMailAddress.password = reader.GetString(3);
                    entMailAddress.port = reader.GetInt32(4);
                }
            }
            return entMailAddress;
        }

        public string GetUserNameByID(int Id)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spGetUserNameByID";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@id", Id);
            DBSqlServer db = new DBSqlServer();
            string mail = string.Empty;
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    mail = reader.GetString(0);
                }
            }
            return mail;
        }
        #endregion
    }
}