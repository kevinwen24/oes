using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace OESModel
{
    [DataContract]
    public class User
    {
        [DataMember]
        public int Id { set; get; }
        [DataMember]
        public string UserId { set; get; }
        [DataMember]
        public string UserName { set; get; }
        [DataMember]
        public string Password { set; get; }
        [DataMember]
        public string Gender { set; get; }
        [DataMember]
        public DateTime CreateTime { set; get; }
        [DataMember]
        public DateTime UpdateTime { set; get; }
        [DataMember]
        public DateTime LastLoginTime { set; get; }
        [DataMember]
        public int RoleId { set; get; }
        [DataMember]
        public int IsActive { set; get; }
    }
}
