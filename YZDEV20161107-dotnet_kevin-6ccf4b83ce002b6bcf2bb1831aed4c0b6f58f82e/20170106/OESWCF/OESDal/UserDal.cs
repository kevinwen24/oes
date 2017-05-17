using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using OESModel;
using OESException;
using OESUtil;
using OESCommon;

namespace OESDal
{
    public class UserDal
    {
        public User GetUserByUserName(string userName) 
        {
            User user = null;
            SqlConnection connection = DBUtil.GetSqlConnection();
            
            try{
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcGetUserByUserName, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterUserName, userName));

                using (SqlDataReader reader = command.ExecuteReader()) 
                {
                    if (reader.Read())
                    {
                        user = new User();
                        user.Id = reader.IsDBNull(0) ? 0 : reader.GetInt32(0);
                        user.UserId = reader.IsDBNull(1) ? string.Empty : reader.GetString(1);
                        user.UserName = reader.IsDBNull(2) ? string.Empty : reader.GetString(2);
                        user.Password = reader.IsDBNull(3) ? string.Empty : reader.GetString(3);
                        user.Gender = reader.IsDBNull(4) ? string.Empty : reader.GetString(4);
                        user.CreateTime = reader.GetDateTime(5);
                        user.UpdateTime = reader.GetDateTime(6);
                        user.LastLoginTime = reader.GetDateTime(7);
                        user.RoleId = reader.IsDBNull(8) ? 0 : reader.GetInt32(8);
                        user.IsActive = reader.IsDBNull(9) ? 0 : reader.GetInt32(9);
                        user.ChineseName = reader.IsDBNull(10) ? string.Empty : reader.GetString(10);
                        user.PhoneNumber = reader.IsDBNull(11) ? string.Empty : reader.GetString(11);
                        user.Email = reader.IsDBNull(12) ? string.Empty : reader.GetString(12);
                    }
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
            return user;
        }


        public void UpdatePasswordByUserId(int userId, string password)
        {
            SqlConnection connection = DBUtil.GetSqlConnection();

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(Constants.ProcUpdatePasswordByUserId, connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterUserId, userId));
                command.Parameters.Add(new SqlParameter(Constants.SqlParameterSortDirection, password));
                command.ExecuteNonQuery();
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
        }
    }
}
