﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DAO
{
    class DBConnect
    {
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            // Data Source=TRAN-VMWARE\SQLEXPRESS;Initial Catalog=simplehr;Persist Security Info=True;User ID=sa;Password=12345
            //
            string connString = @"Data Source=DESKTOP-3DQNB33\TVHUY;Initial Catalog=ThietBi;Integrated Security=True";

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}
