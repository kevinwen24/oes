using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using OESCommon;

namespace OESUtil
{
    public class DBUtil
    {

        public static SqlConnection GetSqlConnection()
        {
            string connectionStr = Constants.DataBaseAddress;
            return new SqlConnection(connectionStr);
        }

        public static void ColseSqlConnection(SqlConnection conn)
        {
            conn.Close();
        }
    }
}
