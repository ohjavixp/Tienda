using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PlataformaComercio.Datos.Fachada;
using System.Data.SqlClient;
using PlataformaComercio.Entities.User;
using PlataformaComercio.FrameWork.DataAccess;

namespace PlataformaComercio.Datos.SqlServer
{
    public class UserDA : IUserDA
    {
        private EntUser FillUser(SqlDataReader reader)
        {
            EntUser entUser = new EntUser();
            entUser.UserID = reader.GetGuid(0);
            entUser.UserName = reader.GetString(1);
            entUser.Password = reader.GetString(2);
            entUser.Name = reader.GetString(3);
            entUser.LastName = reader.GetString(4);
             entUser.EmailAddress = reader.GetString(5);
             entUser.BirthDate = reader.GetDateTime(6);
             entUser.PhoneNumber = reader.GetString(7);
             entUser.PhoneNumberExtension = reader[8] == DBNull.Value?string.Empty:reader.GetString(8);
            entUser.MobileNumber= reader[9] == DBNull.Value?string.Empty:reader.GetString(9);
            entUser.Sex = reader.GetBoolean(10);
            entUser.SendInfo = reader.GetBoolean(11);
             entUser.ShareInfo = reader.GetBoolean(12);

            return entUser;
        }
        
        #region IUserDA Members

        public void Add(Entities.User.EntUser entUser)
        {            
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "INSERT INTO [dbo].[Usuario] VALUES (@UserId,@UserName,@Password,@Name,@LastName,@EmailAddress,@BirthDate,@PhoneNumber,@PhoneNumberExt,@MobileNumber,@Sex,@SendInfo,@ShareInfo)";            
            comando.Parameters.AddWithValue("@UserId",entUser.UserID);
            comando.Parameters.AddWithValue("@UserName", entUser.UserName);
            comando.Parameters.AddWithValue("@Password", entUser.Password);
            comando.Parameters.AddWithValue("@Name", entUser.Name);
            comando.Parameters.AddWithValue("@LastName", entUser.LastName);
            comando.Parameters.AddWithValue("@EmailAddress", entUser.EmailAddress);
            comando.Parameters.AddWithValue("@BirthDate", entUser.BirthDate);
            comando.Parameters.AddWithValue("@PhoneNumber", entUser.PhoneNumber);
            comando.Parameters.AddWithValue("@PhoneNumberExt", entUser.PhoneNumberExtension);
            comando.Parameters.AddWithValue("@MobileNumber", entUser.MobileNumber);
            comando.Parameters.AddWithValue("@Sex", entUser.Sex);
            comando.Parameters.AddWithValue("@SendInfo", entUser.SendInfo);
            comando.Parameters.AddWithValue("@ShareInfo", entUser.ShareInfo);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
        }

        public int AddAddress(EntUserAddress entUserAddress)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spUsuarioDireccion_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@UserId",entUserAddress.UserID);
            comando.Parameters.AddWithValue("@CountryId",entUserAddress.CountryID);
            comando.Parameters.AddWithValue("@ZipCode",entUserAddress.ZipCode);
            comando.Parameters.AddWithValue("@NeighborghoodID", entUserAddress.NeighborghoodID);
            comando.Parameters.AddWithValue("@Street",entUserAddress.Street);
            comando.Parameters.AddWithValue("@StreetNumber",entUserAddress.StreetNumber);
            comando.Parameters.AddWithValue("@StreetInternalNumber",entUserAddress.StreetInternalNumber);
            comando.Parameters.AddWithValue("@StreetBetween",entUserAddress.StreetBetween);
            comando.Parameters.AddWithValue("@AddressName",entUserAddress.AddressName);
            comando.Parameters.AddWithValue("@TelephoneContact",entUserAddress.TelephoneContact);
            comando.Parameters.AddWithValue("@Comments",entUserAddress.Comments);

            DBSqlServer db = new DBSqlServer();
            return (int)db.ExecuteScalar(comando);
        }

        public bool UpdateAddress(EntUserAddress entUserAddress)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spUsuarioDireccion_Update";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@UserId", entUserAddress.UserID);
            comando.Parameters.AddWithValue("@AddressId", entUserAddress.AddressID);
            comando.Parameters.AddWithValue("@CountryId", entUserAddress.CountryID);
            comando.Parameters.AddWithValue("@ZipCode", entUserAddress.ZipCode);
            comando.Parameters.AddWithValue("@NeighborghoodID", entUserAddress.NeighborghoodID);
            comando.Parameters.AddWithValue("@Street", entUserAddress.Street);
            comando.Parameters.AddWithValue("@StreetNumber", entUserAddress.StreetNumber);
            comando.Parameters.AddWithValue("@StreetInternalNumber", entUserAddress.StreetInternalNumber);
            comando.Parameters.AddWithValue("@StreetBetween", entUserAddress.StreetBetween);
            comando.Parameters.AddWithValue("@AddressName", entUserAddress.AddressName);
            comando.Parameters.AddWithValue("@TelephoneContact", entUserAddress.TelephoneContact);
            comando.Parameters.AddWithValue("@Comments", entUserAddress.Comments);

            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }

        public EntUserAddress GetAddressByID(Guid userID, int addressID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM UsuarioDireccion WHERE UserID=@UserID AND AddressID=@AddressID";
            comando.Parameters.AddWithValue("@UserID", userID);
            comando.Parameters.AddWithValue("@AddressID", addressID);

            DBSqlServer db = new DBSqlServer();
            EntUserAddress entUserAddress = null;

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entUserAddress = new EntUserAddress();
                    entUserAddress.UserID = reader.GetGuid(0);
                    entUserAddress.AddressID = reader.GetInt32(1);
                    entUserAddress.CountryID = reader.GetInt32(2);
                    entUserAddress.ZipCode = reader.GetString(3);
                    entUserAddress.NeighborghoodID = reader.GetInt32(4);
                    entUserAddress.Street = reader.GetString(5);
                    entUserAddress.StreetNumber = reader.GetString(6);
                    entUserAddress.StreetInternalNumber = reader.GetString(7);
                    entUserAddress.StreetBetween = reader.GetString(8);
                    entUserAddress.AddressName = reader.GetString(9);
                    entUserAddress.TelephoneContact = reader.GetString(10);
                    entUserAddress.Comments = reader.GetString(11);
                }
            }

            return entUserAddress;
        }


        public Entities.User.EntUser GetByID(Guid userID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM Usuario WHERE UserID=@UserID";
            comando.Parameters.AddWithValue("@UserID", userID);            

            DBSqlServer db = new DBSqlServer();
            EntUser entUser = null;

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entUser = FillUser(reader);                    
                }
            }

            return entUser;
        }

        

        public Entities.User.EntUser GetByEmail(string email)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM Usuario WHERE EmailAddress=@EmailAddress";
            comando.Parameters.AddWithValue("@EmailAddress", email);            

            DBSqlServer db = new DBSqlServer();
            EntUser entUser = null;

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entUser = FillUser(reader);                    
                }
            }

            return entUser;
        }

        public Entities.User.EntUser GetByUserName(string userName)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM Usuario WHERE UserName=@UserName";
            comando.Parameters.AddWithValue("@UserName", userName);            

            DBSqlServer db = new DBSqlServer();
            EntUser entUser = null;

            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entUser = FillUser(reader);                    
                }
            }

            return entUser;
        }

        

        #endregion
    }
}
