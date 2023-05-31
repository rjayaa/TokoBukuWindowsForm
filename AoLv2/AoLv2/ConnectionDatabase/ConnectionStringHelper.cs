using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoLv2.ConnectionHelper
{
    class ConnectionStringHelper
    {
        public static string GetConnectionString()
        {
            string serverName = "(local)\\SQLEXPRESS"; // nama server SQL Server
            string databaseName = "TokoBukuu"; // nama database
            string userName = ""; // nama pengguna SQL Server
            string password = ""; // kata sandi pengguna SQL Server

            // membuat string koneksi dengan menggunakan SQL Server Authentication
            // "Integrated Security=false" menandakan bahwa koneksi menggunakan SQL Server Authentication
            // "User ID" dan "Password" digunakan untuk menyertakan informasi kredensial
            string connectionString = $"Server={serverName};Database={databaseName};Integrated Security=true;User ID={userName};Password={password};";

            // alternatif cara, membuat string koneksi dengan menggunakan Windows Authentication
            // "Integrated Security=true" menandakan bahwa koneksi menggunakan Windows Authentication
            //string connectionString = $"Server={serverName};Database={databaseName};Integrated Security=true;";

            return connectionString;
        }
    }
}
