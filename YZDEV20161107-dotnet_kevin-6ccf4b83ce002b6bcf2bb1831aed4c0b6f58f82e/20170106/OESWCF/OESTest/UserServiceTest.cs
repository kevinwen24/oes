using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OESUtil;
using System.Data.SqlClient;
using System.Data;
using OESLogic;
using OESModel;
using System.ServiceModel;
using OESException;

namespace OESTest
{
    [TestClass]
    public class UserServiceTest
    {
        private int userId;
        private UserService userService;
        private User user;
        private string password;

        [TestInitialize]
        public void TestInitialize()
        {
            userService = new UserService();
            SqlConnection connection = null;
            password = Md5Util.EncryptStringWithMD5("123");

            try
            {
                string sqlCreateuser = "INSERT INTO [user] values('T000020','zs','zhangsan','" + password + "','male','2016-12-18 20:10:10.223','2016-12-18 20:10:10.223','2016-12-18 20:10:10.223',4,0,'1812312656','2312656@163.com'); select  @@IDENTITY as 'id'";
                Console.WriteLine(sqlCreateuser);
                connection = DBUtil.GetSqlConnection();
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlCreateuser;
                SqlDataReader reader = sqlCommand.ExecuteReader();       
                while (reader.Read())
                {
                    userId = (int)reader[0];
                }
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }   
        }

        [TestMethod]
        public void LoginTest()
        {
            Assert.IsNotNull(user);
            Assert.AreEqual(user.Password, password);
        }

        [TestMethod]
        public void LoginUserNotExistTest()
        {
            user = userService.VerifyUserLogin("zs1", password);
            Assert.IsNull(user);
        }

        [TestMethod]
        [ExpectedException(typeof(FaultException<ServiceException>))]
        public void LoginWithIncorrectPasswordTest()
        {
            user = userService.VerifyUserLogin("zs", password + "4");
            Assert.AreNotEqual(user.Password, password + "4");
        }

        [TestCleanup]
        public void cleanUp()
        {
            SqlConnection connection = null;

            try
            {
                string sqlDeleteExamQuestion = "DELETE FROM [user] WHERE user_id = " + userId + ";";
                connection = DBUtil.GetSqlConnection();
                SqlCommand sqlCommand = connection.CreateCommand();
                sqlCommand.CommandType = CommandType.Text;
                sqlCommand.CommandText = sqlDeleteExamQuestion;
                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                DBUtil.ColseSqlConnection(connection);
            }
        }
    }
}
