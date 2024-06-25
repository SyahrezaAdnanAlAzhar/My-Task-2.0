using MySql.Data.MySqlClient;

namespace MyTaskAPI.Controllers
{
    public class Database
    {
        private string connectionString;

        public Database(string server, string database, string username)
        {
            connectionString = $"Server={server}; database={database}; UID={username};";
        }

        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }

        public void OpenConnection(MySqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void CloseConnection(MySqlConnection connection)
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}
