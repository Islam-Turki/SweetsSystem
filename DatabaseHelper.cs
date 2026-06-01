using System;
using System.Data;
using System.Configuration;
using Microsoft.Data.SqlClient;

namespace sweetSystem
{
    public static class DatabaseHelper
    {
        private static string GetConnectionString()
        {
            var connectionStringSettings = ConfigurationManager.ConnectionStrings["TajAsalDB"];
            if (connectionStringSettings == null)
            {
                throw new InvalidOperationException("Connection string 'TajAsalDB' not found in App.config.");
            }
            return connectionStringSettings.ConnectionString;
        }

        public static DataTable ExecuteQuery(string query, SqlParameter[]? parameters = null)
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Database query execution failed: {ex.Message}", ex);
            }

            return dataTable;
        }

        public static int ExecuteNonQuery(string query, SqlParameter[]? parameters = null)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        if (parameters != null)
                        {
                            command.Parameters.AddRange(parameters);
                        }

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Database command execution failed: {ex.Message}", ex);
            }

            return rowsAffected;
        }
    }
}
