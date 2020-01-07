using System;
using System.Data.SqlClient;
using System.Windows;

namespace ARM_Of_Phone_seller_PROJECT.Database_Logic
{
    internal class DBController : IDisposable
    {
        private static string db = Properties.Settings.Default.ИмяСервера;
        private static string user = Properties.Settings.Default.ИмяПользователя;
        public static string DBController_DBName { get => db; set => db = value; }
        public static string DBController_User { get => user; set => user = value; }
        private static string Path => $"Data Source={Properties.Settings.Default.ИмяПользователя};Initial Catalog={Properties.Settings.Default.ИмяСервера};Integrated Security=True";

        private SqlConnection connection;
        public bool ErrorOccured { get; private set; } = false;
        public DBController()
        {
            connection = new SqlConnection(Path);
            try
            {
                connection.Open();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message, "Ошибка SQL Сервера", MessageBoxButton.OK, MessageBoxImage.Error);
                ErrorOccured = true;
            }
        }

        public DBController(bool IsMaster)
        {
            if (IsMaster)
            {
                connection = new SqlConnection($"Data Source={Properties.Settings.Default.ИмяПользователя};Initial Catalog=master;Integrated Security=True");
                try
                {
                    connection.Open();
                }
                catch (SqlException e)
                {
                    MessageBox.Show(e.Message, "Ошибка SQL Сервера", MessageBoxButton.OK, MessageBoxImage.Error);
                    ErrorOccured = true;
                }
            }
        }
        public void Dispose()
        {
            connection.Close();
        }

        public void ExecuteNonQueryCommand(string command)
        {
            command = command.Replace("GO", "");
            using (SqlCommand sqlCom = new SqlCommand(command, connection))
            {
                if (!ErrorOccured)
                    sqlCom.ExecuteNonQuery();
            }
        }
        public SqlDataReader ExecuteReader(string command)
        {
            SqlDataReader reader = null;

            using (SqlCommand sqlCom = new SqlCommand(command, connection))
            {
                if (!ErrorOccured)
                    reader = sqlCom.ExecuteReader();
            }
            if (!ErrorOccured)
                return reader;
            else
                return null;
        }
    }
}
