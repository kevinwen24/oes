using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OESModel
{
    public class User
    {
        public int Id { set; get; }

        public string UserId { set; get; }

        public string UserName { set; get; }

        public string Password { set; get; }

        public string Gender { set; get; }

        public DateTime CreateTime { set; get; }

        public DateTime UpdateTime { set; get; }

        public DateTime LastLoginTime { set; get; }

        public int RoleId { set; get; }

        public int IsActive { set; get; }
    }
}
