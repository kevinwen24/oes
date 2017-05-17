using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESDal;
using OESModel;
using OESUtil;
using OESCommon;

namespace OESLogic
{
    public class UserManager
    {
        public bool verifyUserLogin(string userName, string password)
        {
            UserDal userDal = new UserDal();
            User user = userDal.Login(userName);
            if (user == null) 
            {
                throw new LogicException(Constants.UserNoExit);
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
