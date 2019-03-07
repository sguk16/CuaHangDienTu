namespace DAO
{
    using System.Data.SqlClient;

    class DBConnect
    {
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            // Data Source=TRAN-VMWARE\SQLEXPRESS;Initial Catalog=simplehr;Persist Security Info=True;User ID=sa;Password=12345
            //
            string connString = @"Data Source=DESKTOP-3DQNB33\TVHUY;Initial Catalog=ThietBi;Integrated Security=True";
            //string connString = @"Data Source=DESKTOP-G6PP4N5;Initial Catalog=ThietBi;User ID=sa;Password=123"; 
            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}
