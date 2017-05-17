using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESDal;
using OESModel;
using OESUtil;
using OESCommon;
using System.ServiceModel;

namespace OESLogic
{
    public class UserService : IUserService
    {
        public bool verifyUserLogin(string userName, string password)
        {
            UserDal userDal = new UserDal();
            User user = userDal.Login(userName);
            if (user == null) 
            {
                throw new FaultException(Constants.UserNoExit);
            }

            if (user.Password == password)
            {
                SessionUtil.User = user;
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
