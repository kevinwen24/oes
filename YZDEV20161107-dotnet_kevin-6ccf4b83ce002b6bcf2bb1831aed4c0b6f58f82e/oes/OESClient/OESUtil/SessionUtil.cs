using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OESModel;

namespace OESUtil
{
    public class SessionUtil
    {
        private static User user;

        public static User User
        {
            set {
                   if (user == null)
                   { 
                      user = value;
                   }
                 }
            get { return user; }
        }

        public static void Remove()
        {
             user = null;
        }
    }
}
