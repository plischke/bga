using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bga_app
{
    public class DBConnection
    {
        private string ConnectionString = string.Format("Server=localhost; database={0}; UID=root; password=tylerp93", "mydb");
        public DBConnection()
        {
        }

        public string getdbconStr()
        {
             return ConnectionString;
        }
    }
}
