﻿namespace DAO
{
    using System.Data.SqlClient;

    class GetConnect
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"DESKTOP-G6PP4N5";
            string database = "ThietBi";
            string username = "sa";
            string password = "123";

            return DBConnect.GetDBConnection(datasource, database, username, password);
        }
    }
}
