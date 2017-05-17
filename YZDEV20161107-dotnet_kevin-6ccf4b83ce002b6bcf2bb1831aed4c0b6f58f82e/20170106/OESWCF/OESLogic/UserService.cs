using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESDal;
using OESModel;
using OESUtil;
using OESCommon;
using System.ServiceModel;
using System.Data.SqlClient;
using OESException;
using log4net;


namespace OESLogic
{
    public class UserService : IUserService
    {
        private UserDal userDal = new UserDal();
        private ILog log = null;

        public UserService()
        {
            log = LogManager.GetLogger(this.GetType());
        }

        public User VerifyUserLogin(string userName, string password)
        {
            User user = null;
            try
            {
                user = userDal.GetUserByUserName(userName);
            }
             catch(SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }
            
            if (user == null) 
            {
                throw new FaultException<ServiceException>(new ServiceException(Constants.UserNoExit));
            }
            if (user.Password == password)
            {
                user.Password = "";
                return user;
            }
            else
            {
                return null;
            } 
        }

        public User GetUserByName(string userName)
        {
            try
            {
                User user = userDal.GetUserByUserName(userName);
                user.Password = "";
                return user;
            }
            catch (SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }
           
        }

        public void ModifyPassword(int userId, string password)
        {
            try
            {
                userDal.UpdatePasswordByUserId(userId, password);
            }
            catch (SqlException sqlException)
            {
                log.Error(sqlException.StackTrace);
                throw new FaultException<DBException>(new DBException(), Constants.ServerError);
            }
        }
    }
}
