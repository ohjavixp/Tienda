using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using PlataformaComercio.Datos.Fachada.Catalog;
using PlataformaComercio.Entities.Catalog;
using PlataformaComercio.FrameWork.DataAccess;

namespace PlataformaComercio.Data
{
    public partial class PropertyDA : IProperty
    {
        public Int32 Add(EntProperty entProperty)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spProperty_Add";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PropertyId", entProperty.PropertyId);
            comando.Parameters.AddWithValue("@Name", entProperty.Name);
            comando.Parameters.AddWithValue("@FriendlyName", entProperty.FriendlyName);
            comando.Parameters.AddWithValue("@PropertyCategoryId", entProperty.PropertyCategoryId);
            comando.Parameters.AddWithValue("@PropertySubCategoryId", entProperty.PropertySubCategoryId);
            comando.Parameters.AddWithValue("@Type", entProperty.Type);
            comando.Parameters.AddWithValue("@IsRequired", entProperty.IsRequired);
            comando.Parameters.AddWithValue("@IsActive", entProperty.IsActive);
            comando.Parameters.AddWithValue("@IsBase", entProperty.IsBase);
            DBSqlServer db = new DBSqlServer();
            return (Int32)db.ExecuteScalar(comando);
        }

        public bool Update(EntProperty entProperty)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spProperty_Update";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PropertyId", entProperty.PropertyId);
            comando.Parameters.AddWithValue("@Name", entProperty.Name);
            comando.Parameters.AddWithValue("@FriendlyName", entProperty.FriendlyName);
            comando.Parameters.AddWithValue("@PropertyCategoryId", entProperty.PropertyCategoryId);
            comando.Parameters.AddWithValue("@PropertySubCategoryId", entProperty.PropertySubCategoryId);
            comando.Parameters.AddWithValue("@Type", entProperty.Type);
            comando.Parameters.AddWithValue("@IsRequired", entProperty.IsRequired);
            comando.Parameters.AddWithValue("@IsActive", entProperty.IsActive);
            comando.Parameters.AddWithValue("@IsBase", entProperty.IsBase);
            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }

        public EntProperty GetByID(Int32 PropertyId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spProperty_Select_By_ID";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PropertyId", PropertyId);
            DBSqlServer db = new DBSqlServer();
            EntProperty entProperty = null;
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entProperty = Fill(reader);
                }
            }
            return entProperty;
        }

        public bool Delete(Int32 PropertyId)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spProperty_Delete";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PropertyId", PropertyId);
            DBSqlServer db = new DBSqlServer();
            db.ExecuteNonQuery(comando);
            return true;
        }
    }

    #region Extended

    public partial class PropertyDA
    {
        public EntProperty[] GetByCategoryAndSubCategoryId(int categoryID, int subCategoryID)
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spProperty_Select_by_CategoryAndSubCategoryID";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PropertyCategoryId", categoryID);
            comando.Parameters.AddWithValue("@PropertySubCategoryId", subCategoryID);
            DBSqlServer db = new DBSqlServer();

            List<EntProperty> entProperty = new List<EntProperty>(); ;
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    entProperty.Add(Fill(reader));
                }
            }
            return entProperty.ToArray();
        }

        private static EntProperty Fill(SqlDataReader reader)
        {
            EntProperty entProperty = new EntProperty();
            entProperty.PropertyId = reader.GetInt32(0);
            entProperty.Name = reader.GetString(1);
            entProperty.FriendlyName = reader.GetString(2);
            entProperty.PropertyCategoryId = reader.GetInt32(3);
            if (reader[4] != DBNull.Value)
                entProperty.PropertySubCategoryId = reader.GetInt32(4);
            entProperty.Type = reader.GetInt16(5);
            entProperty.IsRequired = reader.GetBoolean(6);
            entProperty.IsActive = reader.GetBoolean(7);
            entProperty.IsBase = reader.GetBoolean(8);
            return entProperty;
        }
    }

    #endregion Extended
}