using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using PlataformaComercio.FrameWork.Configuracion;

namespace PlataformaComercio.FrameWork.DataAccess
{
    public class DBSqlServer
    {
        private void SanitizeParameters(SqlCommand command)
        {
            Regex reg = new Regex(@"[^a-zA-Z0-9 .@]ñÑ");

            foreach (SqlParameter item in command.Parameters)
            {
                switch (item.SqlDbType)
                {
                    case System.Data.SqlDbType.BigInt:
                    case System.Data.SqlDbType.Binary:
                    case System.Data.SqlDbType.Bit:
                    case System.Data.SqlDbType.Char:
                    case System.Data.SqlDbType.Date:
                    case System.Data.SqlDbType.DateTime:
                    case System.Data.SqlDbType.DateTime2:
                    case System.Data.SqlDbType.DateTimeOffset:
                    case System.Data.SqlDbType.Decimal:
                    case System.Data.SqlDbType.Float:
                    case System.Data.SqlDbType.Image:
                    case System.Data.SqlDbType.Int:
                    case System.Data.SqlDbType.Money:
                    case System.Data.SqlDbType.Real:
                    case System.Data.SqlDbType.SmallDateTime:
                    case System.Data.SqlDbType.SmallInt:
                    case System.Data.SqlDbType.SmallMoney:
                    case System.Data.SqlDbType.Structured:
                    case System.Data.SqlDbType.Time:
                    case System.Data.SqlDbType.Timestamp:
                    case System.Data.SqlDbType.TinyInt:
                    case System.Data.SqlDbType.Udt:
                    case System.Data.SqlDbType.UniqueIdentifier:
                    case System.Data.SqlDbType.VarBinary:
                    case System.Data.SqlDbType.Xml:
                        //System.Diagnostics.Debug.WriteLine(string.Format("Sin reemplazar valor de {0}", item.Value));
                        break;
                    case System.Data.SqlDbType.NChar:
                    case System.Data.SqlDbType.NText:
                    case System.Data.SqlDbType.NVarChar:
                    case System.Data.SqlDbType.Text:
                    case System.Data.SqlDbType.VarChar:
                    case System.Data.SqlDbType.Variant:
                        //System.Diagnostics.Debug.WriteLine(string.Format("Reemplanzando valor {0} por {1}", item.Value, reg.Replace(item.Value.ToString(), string.Empty)));
                        item.Value = reg.Replace(item.Value.ToString(), string.Empty);
                        break;
                }


            }
        }


        public object ExecuteScalar(SqlCommand command)
        {
            SqlConnection conn = null;

            try
            {
                SanitizeParameters(command);
                conn = GetConnection();
                command.Connection = conn;
                conn.Open();
                return command.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();

                conn.Dispose();
            }
        }

        public void ExecuteNonQuery(SqlCommand command)
        {
            SqlConnection conn = null;

            try
            {
                SanitizeParameters(command);
                conn = GetConnection();
                command.Connection = conn;
                conn.Open();
                command.ExecuteNonQuery();
            }
            catch (SqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null && conn.State != System.Data.ConnectionState.Closed)
                    conn.Close();

                conn.Dispose();
            }
        }

        public SqlDataReader ExecuteReader(SqlCommand command)
        {
            SqlConnection conn = null;

            try
            {
                SanitizeParameters(command);
                conn = GetConnection();
                command.Connection = conn;
                conn.Open();
                
                return command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            }
            catch (Exception)
            {
                throw;
            }
        }


        public SqlConnection GetConnection()
        {
            return new SqlConnection(GeneralConfiguration.ConnectionString);

        }
    }
}
