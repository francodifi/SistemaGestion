using System.Data.SqlClient;

namespace SistemaGestionData
{
    public static class DatabaseConnection
    {
        private static readonly string connectionString = "Server=server;Database=database;User Id=username;Password=password;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}