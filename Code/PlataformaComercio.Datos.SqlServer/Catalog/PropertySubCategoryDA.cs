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
	public class PropertySubCategoryDA : IPropertySubCategory
	{
		public bool Add(EntPropertySubCategory entPropertySubCategory)
		{
			SqlCommand comando = new SqlCommand();
			comando.CommandText = "spPropertySubCategory_Add";
			comando.CommandType = System.Data.CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@PropertyCategoryId", entPropertySubCategory.PropertyCategoryId);
			comando.Parameters.AddWithValue("@PropertySubCategoryId", entPropertySubCategory.PropertySubCategoryId);
			comando.Parameters.AddWithValue("@Name", entPropertySubCategory.Name);
			comando.Parameters.AddWithValue("@IsActive", entPropertySubCategory.IsActive);
			DBSqlServer db = new DBSqlServer();
			return (bool)db.ExecuteScalar(comando);
		}

		public bool Update(EntPropertySubCategory entPropertySubCategory)
		{
			SqlCommand comando = new SqlCommand();
			comando.CommandText = "spPropertySubCategory_Update";
			comando.CommandType = System.Data.CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@PropertyCategoryId", entPropertySubCategory.PropertyCategoryId);
			comando.Parameters.AddWithValue("@PropertySubCategoryId", entPropertySubCategory.PropertySubCategoryId);
			comando.Parameters.AddWithValue("@Name", entPropertySubCategory.Name);
			comando.Parameters.AddWithValue("@IsActive", entPropertySubCategory.IsActive);
			DBSqlServer db = new DBSqlServer();
			db.ExecuteNonQuery(comando);
			return true;
		}

		public EntPropertySubCategory GetByID(Int32 PropertyCategoryId, Int32 PropertySubCategoryId)
		{
			SqlCommand comando = new SqlCommand();
			comando.CommandText = "spPropertySubCategory_Select_By_ID";
			comando.CommandType = System.Data.CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@PropertyCategoryId", PropertyCategoryId);
			comando.Parameters.AddWithValue("@PropertySubCategoryId", PropertySubCategoryId);
			DBSqlServer db = new DBSqlServer();
			EntPropertySubCategory entPropertySubCategory = null;
			using (SqlDataReader reader = db.ExecuteReader(comando))
			{
				if(reader.Read())
				{
                    entPropertySubCategory = Fill(reader);
				}
			}
			return entPropertySubCategory;
		}

        private static EntPropertySubCategory Fill(SqlDataReader reader)
        {
            EntPropertySubCategory entPropertySubCategory = new EntPropertySubCategory();
            entPropertySubCategory.PropertyCategoryId = reader.GetInt32(0);
            entPropertySubCategory.PropertySubCategoryId = reader.GetInt32(1);
            entPropertySubCategory.Name = reader.GetString(2);
            entPropertySubCategory.IsActive = reader.GetBoolean(3);
            return entPropertySubCategory;
        }

		public bool Delete(Int32 PropertyCategoryId, Int32 PropertySubCategoryId)
		{
			SqlCommand comando = new SqlCommand();
			comando.CommandText = "spPropertySubCategory_Delete";
			comando.CommandType = System.Data.CommandType.StoredProcedure;
			comando.Parameters.AddWithValue("@PropertyCategoryId", PropertyCategoryId);
			comando.Parameters.AddWithValue("@PropertySubCategoryId", PropertySubCategoryId);
			DBSqlServer db = new DBSqlServer();
			db.ExecuteNonQuery(comando);
			return true;
		}

        public EntPropertySubCategory[] GetByCategoryID(Int32 PropertyCategoryId)
        {
            //
            SqlCommand comando = new SqlCommand();
            comando.CommandText = "spPropertySubCategory_Select_by_CategoryID";
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@PropertyCategoryId", PropertyCategoryId);
            
            DBSqlServer db = new DBSqlServer();
            List<EntPropertySubCategory> entPropertySubCategory = new List<EntPropertySubCategory>();
            using (SqlDataReader reader = db.ExecuteReader(comando))
            {
                if (reader.Read())
                {
                    entPropertySubCategory.Add( Fill(reader));
                }
            }
            return entPropertySubCategory.ToArray();
        }
	}
}

