using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ARM_Of_Phone_seller_PROJECT.Database_Logic
{
    class DBController : IDisposable
    {
        private static string db = Properties.Settings.Default.ИмяСервера;
        private static string user = Properties.Settings.Default.ИмяПользователя;
        public static string DBController_DBName { get => db; set => db = value; }
        public static string DBController_User { get => user; set => user = value; }
        private static string Path
        {
            get
            {
                return $"Data Source={Properties.Settings.Default.ИмяПользователя};Initial Catalog={Properties.Settings.Default.ИмяСервера};Integrated Security=True";
            }
        }

        SqlConnection connection;

        public DBController()
        {
            connection = new SqlConnection(Path);
            connection.Open();
        }
        public void Dispose()
        {
            connection.Close();
        }

        public void ExecuteNonQueryCommand(string command)
        {
            using (var sqlCom = new SqlCommand(command, connection))
            {
                sqlCom.ExecuteNonQuery();
            }
        }
        public SqlDataReader ExecuteReader(string command)
        {
            SqlDataReader reader = null;

            using (var sqlCom = new SqlCommand(command, connection))
            {
                reader = sqlCom.ExecuteReader();
            }

            return reader;
        }
    }
}
