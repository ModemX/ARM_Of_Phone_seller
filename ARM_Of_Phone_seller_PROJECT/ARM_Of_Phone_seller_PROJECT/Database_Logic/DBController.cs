﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ARM_Of_Phone_seller_PROJECT.Database_Logic
{
    class DBController : IDisposable
    {
        private static string db = "ARM_Of_Phone_Seller";
        private static string user = "SADMODSNOTEBOOK\\SQLEXPRESS";
        public static string DBController_DBName { get => db; set => db = value; }
        public static string DBController_User { get => user; set => user = value; }
        private static string Path
        {
            get
            {
                return $"Data Source={DBController_User};Initial Catalog={DBController_DBName};Integrated Security=True";
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
