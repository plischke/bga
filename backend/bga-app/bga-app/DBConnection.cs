using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bga_app
{
    public class DBConnection
    {
        private DBConnection()
        {
        }

        private string databaseName = "mydb";
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }
        private MySqlConnection connection = null;
        public MySqlConnection Connection
        {
            get { return connection; }
        }

        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;
        }

        public bool IsConnect()
        {
            if (Connection == null)
            {
                if (String.IsNullOrEmpty(databaseName))
                    return false;
                string connstring = string.Format("Server=localhost; database={0}; UID=root; password=tylerp93", databaseName);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }

            return true;
        }
        //fix later
        public void Close()
        {
            connection.Close();
            _instance = null;
        }

    }
}
