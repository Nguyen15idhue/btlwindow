using MySql.Data.MySqlClient;

namespace btlwindow
{
    public static class DbConfig
    {
        private static string _connectionString;

        public static string ConnectionString
        {
            get
            {
                if (string.IsNullOrEmpty(_connectionString))
                {
                    _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["MySQL"]?.ConnectionString;
                    
                    if (string.IsNullOrEmpty(_connectionString))
                    {
                        _connectionString = "Server=localhost;Database=kanban_simple;Port=3306;User Id=root;Password=;";
                    }
                }
                return _connectionString;
            }
            set => _connectionString = value;
        }

        public static MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConnectionString);
        }
    }
}
