using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using OESModel;
using OESException;
using OESUtil;

namespace OESDal
{
    public class UserDal
    {
        public User Login(string userName) 
        {
            User user = null;
            SqlConnection connection = DBUtil.GetSqlConnection();
            
            try{
                connection.Open();
                SqlCommand command = new SqlCommand("procGetUserByUserName", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter("@userName", userName));

                using (SqlDataReader reader = command.ExecuteReader()) 
                {
                    if (reader.Read())
                    {
                        user = new User();
                        user.Id = reader[0] == null ? 0 : reader.GetInt32(0);
                        user.UserId = reader[1] == null ? string.Empty : reader.GetString(1);
                        user.UserName = reader[2] == null ? string.Empty : reader.GetString(2);
                        user.Password = reader[3] == null ? string.Empty : reader.GetString(3);
                        user.Gender = reader[4] == null ? string.Empty : reader.GetString(4);
                        user.CreateTime = reader.GetDateTime(5);
                        user.UpdateTime = reader.GetDateTime(6);
                        user.LastLoginTime = reader.GetDateTime(7);
                        user.RoleId = reader[8] == null ? 0 : reader.GetInt32(8);
                        user.IsActive = reader[9] == null ? 0 : reader.GetInt32(9);
                    }
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("data access error {0}", e.StackTrace);
                throw new DBException();  
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
            return user;
        }
        
    }
}
