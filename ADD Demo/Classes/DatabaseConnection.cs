using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace ADD_Demo.Classes
{
    public class DatabaseConnection
    {

        public static SqlConnection GetConnection()
        {
            // Load connection string from web.config
            System.Configuration.Configuration config = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("/");
            System.Configuration.ConnectionStringSettings connString = config.ConnectionStrings.ConnectionStrings["ADDDatabase"];

            // Setup Connection
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString.ConnectionString;

            return conn;
        }

        public static SqlCommand GetCommand(String storedProcedure, SqlConnection conn)
        {
            SqlCommand comm = new SqlCommand();
            comm.CommandType = CommandType.StoredProcedure;
            comm.CommandText = storedProcedure;
            comm.Connection = conn;
            return comm;
        }
    }
}