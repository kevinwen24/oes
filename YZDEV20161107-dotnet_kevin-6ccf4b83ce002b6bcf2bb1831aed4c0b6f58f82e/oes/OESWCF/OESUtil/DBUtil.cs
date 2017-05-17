using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace OESUtil
{
    public class DBUtil
    {

        public static SqlConnection GetSqlConnection()
        {
          string connectionStr = "Data Source=YT00701\\SQLEXPRESS;Initial Catalog=oes;Integrated Security=SSPI;";
          return new SqlConnection(connectionStr);
        }

        public static void ColseSqlConnection(SqlConnection conn)
        {
            conn.Close();
        }
    }
}
