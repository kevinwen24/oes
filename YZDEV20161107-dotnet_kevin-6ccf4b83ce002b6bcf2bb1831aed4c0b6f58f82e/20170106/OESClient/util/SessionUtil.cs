using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESModel;

namespace util
{
    public class SessionUtil
    {
        private static User user;

        public static User User
        {
            set { user = value; }
            get{return user;}
        }
    }
}
