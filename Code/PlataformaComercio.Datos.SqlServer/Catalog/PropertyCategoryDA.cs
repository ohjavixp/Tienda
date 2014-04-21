using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Microsoft.SqlServer;
using PlataformaComercio.FrameWork.DataAccess;

using PlataformaComercio.Entities;
using PlataformaComercio.Datos.Fachada.Catalog;
using PlataformaComercio.Entities.Catalog;
using System.Collections.Generic;

namespace PlataformaComercio.Datos.SqlServer.Catalog
{
	public class PropertyCategoryDA : IPropertyCategory
	{
		public Int32 Add(EntPropertyCategory entPropertyCategory)
		{
			SqlCommand comando = new SqlCommand();
			comando.CommandText = "spPropertyCategory_Add";
			comando.CommandType = System.Data.CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@PropertyCategoryId", entPropertyCategory.PropertyCategoryId);
			comando.Parameters.AddWithValue("@Name", entPropertyCategory.Name);
			comando.Parameters.AddWithValue("@IsActive", entPropertyCategory.IsActive);
			DBSqlServer db = new DBSqlServer();
			return (Int32)db.ExecuteScalar(comando);
		}

		public bool Update(EntPropertyCategory entPropertyCategory)
		{
			SqlCommand comando = new SqlCommand();
			comando.CommandText = "spPropertyCategory_Update";
			comando.CommandType = System.Data.CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@PropertyCategoryId", entPropertyCategory.PropertyCategoryId);
			comando.Parameters.AddWithValue("@Name", entPropertyCategory.Name);
			comando.Parameters.AddWithValue("@IsActive", entPropertyCategory.IsActive);
			DBSqlServer db = new DBSqlServer();
			db.ExecuteNonQuery(comando);
			return true;
		}

		public EntPropertyCategory GetByID(Int32 PropertyCategoryId)
		{
			SqlCommand comando = new SqlCommand();
			comando.CommandText = "spPropertyCategory_Select_By_ID";
			comando.CommandType = System.Data.CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@PropertyCategoryId", PropertyCategoryId);
			DBSqlServer db = new DBSqlServer();
			EntPropertyCategory entPropertyCategory = null;
			using (SqlDataReader reader = db.ExecuteReader(comando))
			{
				if(reader.Read())
				{
                    entPropertyCategory = Fill(reader);
				}
			}
			return entPropertyCategory;
		}

        private static EntPropertyCategory Fill(SqlDataReader reader)
        {
            EntPropertyCategory entPropertyCategory = new EntPropertyCategory();
            entPropertyCategory.PropertyCategoryId = reader.GetInt32(0);
            entPropertyCategory.Name = reader.GetString(1);
            entPropertyCategory.IsActive = reader.GetBoolean(2);
            return entPropertyCategory;
        }

		public bool Delete(Int32 PropertyCategoryId)
		{
			SqlCommand comando = new SqlCommand();
			comando.CommandText = "spPropertyCategory_Delete";
			comando.CommandType = System.Data.CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@PropertyCategoryId", PropertyCategoryId);
			DBSqlServer db = new DBSqlServer();
			db.ExecuteNonQuery(comando);
			return true;
		}

        public EntPropertyCategory[] GetAll()
        {
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "SELECT * FROM PropertyCategory";

            DBSqlServer db = new DBSqlServer();
            List<EntPropertyCategory> entPropertyCategory = new List<EntPropertyCategory>();
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                while (reader.Read())
                {
                    entPropertyCategory.Add( Fill(reader));
                }
            }

            return entPropertyCategory.ToArray();
        }
	}
}

