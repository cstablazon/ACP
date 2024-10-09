using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ACP
{
    class DatabaseHelper
    {
        private static string _connectionString = Properties.Settings.Default.connectionDB;

        // Static method to return a SQL connection instance
        public static SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        // Execute a stored procedure and return a scalar result can be use to insert, update and delete
        public static string ExecuteStoredProcedure(string storedProcedureName, Dictionary<string, object> parameters)
        {
            string result = string.Empty;

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters dynamically from the dictionary
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(param.Key, param.Value ?? DBNull.Value));
                        }

                        // Execute the command and check for null result
                        object scalarResult = cmd.ExecuteScalar();
                        if (scalarResult != null)
                        {
                            result = scalarResult.ToString();
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                throw;
            }

            return result;
        }

        // Fetch records for populating a ComboBox
        public static DataSet GetRecordsForComboBox(string storedProcedure, string tableName, string action, string datasetName)
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        //cmd.Parameters.AddWithValue("@tableName", tableName);
                        cmd.Parameters.AddWithValue("@action", action);

                        using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            adt.Fill(ds, datasetName);
                            return ds;
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                throw;
            }
        }

        //Fetch records dynamically with variable descriptions
        public static DataTable GetRecords(string storedProcedure, string action, params object[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@action", action ?? (object)DBNull.Value);

                        // Add dynamic parameters
                        for (int i = 0; i < parameters.Length; i += 2)
                        {
                            string paramName = parameters[i] as string;
                            object paramValue = parameters[i + 1] ?? DBNull.Value;
                            cmd.Parameters.AddWithValue(paramName, paramValue);
                        }

                        using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                        {
                            adt.Fill(dt);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                throw;
            }
            return dt;
        }

        // Fetch records dynamically with variable descriptions and filtering by ID, name, or other parameters
        public static DataTable GetFilteredRecords(string storedProcedure, string action, params object[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@action", action ?? (object)DBNull.Value);

                        // Add dynamic filtering parameters (e.g., ID, name, etc.)
                        for (int i = 0; i < parameters.Length; i += 2)
                        {
                            string paramName = parameters[i] as string;
                            object paramValue = parameters[i + 1] ?? DBNull.Value;
                            cmd.Parameters.AddWithValue(paramName, paramValue);
                        }

                        using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                        {
                            adt.Fill(dt);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                throw;
            }
            return dt;
        }

        public static DataTable SearchRecords(string storedProcedure, string action, Dictionary<string, object> parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@action", action ?? (object)DBNull.Value);

                        // Add dynamic search parameters
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                        }

                        using (SqlDataAdapter adt = new SqlDataAdapter(cmd))
                        {
                            adt.Fill(dt);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                throw;
            }
            return dt;
        }

        // New method to execute a stored procedure and return a DataSet
        public static DataSet ExecuteStoredProcedureWithDataSet(string storedProcedureName, Dictionary<string, object> parameters)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(storedProcedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters dynamically from the dictionary
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.Add(new SqlParameter(param.Key, param.Value ?? DBNull.Value));
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(ds);
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                LogError(sqlEx.Message);
                throw;
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                throw;
            }

            return ds;
        }

        // Method for logging errors
        private static void LogError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
