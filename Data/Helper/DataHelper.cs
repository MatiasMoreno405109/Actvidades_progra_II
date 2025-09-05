using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Microsoft.Data.SqlClient;

namespace proyecto_Practica01_.Data.Helper
{
    public class DataHelper
    {
        private static DataHelper _instance;
        private SqlConnection _connection;
        private string _cnnString = @"Data Source=DESKTOP-07VO04H\SQLEXPRESS;Initial Catalog=LIBRERIA_ACTIVIDAD_1;Integrated Security=True;Encrypt=False";
        private DataHelper()
        {
            _connection = new SqlConnection(_cnnString);
        }
        public static DataHelper GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DataHelper();
            }
            return _instance;
        }
        public DataTable ExecuteSpQuery(string sp, List<SpParameter>? parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (SpParameter p in parameters)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Valor);
                    }
                }
                dt.Load(cmd.ExecuteReader());
            }
            catch (SqlException ex)
            {
                dt = null;
            }
            finally
            {
                _connection.Close();
            }
            return dt;

        }
        public bool ExecuteSpDml(string sp, List<SpParameter>? parameters)
        {
            bool result;
            try
            {
                _connection.Open();
                var cmd = new SqlCommand(sp, _connection);
                cmd.CommandType = CommandType.StoredProcedure;

                if(parameters != null)
                {
                    foreach (SpParameter p in parameters)
                    {
                        cmd.Parameters.AddWithValue(p.Name, p.Valor);
                    }
                }
                int affectedRows = cmd.ExecuteNonQuery();

                result = affectedRows > 0;
            }
            catch(SqlException ex)
            {
                return false;
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }
    }
}
